import { doc, increment, setDoc, collection, getDocs, query, orderBy, limit, deleteDoc } from "firebase/firestore";
import { db } from "../config/firebase";
import { Pet } from "../types";
import { applyStepsToPet } from "./pets/applyStepsToPet";
import { getTodayKey, getWeekKey, toDateKey } from "./stepStats";

const pruneOldDailySteps = async (userId: string) => {
    const cutoff = new Date();
    cutoff.setDate(cutoff.getDate() - 14);
    const cutoffKey = toDateKey(cutoff);

    const snap = await getDocs(
        query(
            collection(db, "users", userId, "dailySteps"),
            orderBy("date", "asc"),
            limit(30)
        )
    );

    await Promise.all(
        snap.docs
            .filter((d) => d.data().date < cutoffKey)
            .map((d) => deleteDoc(d.ref))
    );
};

export const syncStepsToFirestore = async (
    userId: string,
    pet: Pet,
    steps: number
): Promise<Pet> => {
    const updatedPet = applyStepsToPet(pet, steps);
    const today = getTodayKey();
    const week = getWeekKey();

    await Promise.all([
        setDoc(
            doc(db, "users", userId, "pets", pet.id),
            {
                level: updatedPet.level,
                stats: updatedPet.stats,
                stepsCurrent: updatedPet.stepsCurrent,
                stepsToNextLevel: updatedPet.stepsToNextLevel,
            },
            { merge: true }
        ),
        setDoc(
            doc(db, "users", userId),
            { stepsTotal: increment(steps), updatedAt: Date.now() },
            { merge: true }
        ),
        setDoc(
            doc(db, "users", userId, "dailySteps", today),
            { date: today, week, steps: increment(steps), updatedAt: Date.now() },
            { merge: true }
        ),
    ]);

    await pruneOldDailySteps(userId);

    return updatedPet;
};