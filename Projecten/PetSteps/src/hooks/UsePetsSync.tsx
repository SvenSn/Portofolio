import { useEffect } from "react";
import { collection, doc, onSnapshot } from "firebase/firestore";

import { db } from "../config/firebase";
import { setPets, setActivePet } from "../store/pets/petSlice";
import { Pet } from "../types";
import { useAppDispatch } from "./ReduxHooks";

export const usePetsSync = (userId: string) => {
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (!userId) return;

        const petsRef = collection(db, "users", userId, "pets");

        const unsubPets = onSnapshot(petsRef, (snapshot) => {
            const pets = snapshot.docs.map((doc) => {
                const data = doc.data();

                return {
                    id: doc.id,

                    type: data.type,
                    name: data.name,

                    level: data.level,

                    imageUrl: data.imageUrl,

                    stepsCurrent: data.stepsCurrent,
                    stepsToNextLevel: data.stepsToNextLevel,

                    baseSteps: data.baseSteps,
                    growthRate: data.growthRate,

                    stats: data.stats,
                } as Pet;
            });

            dispatch(setPets(pets));
        });

        const userRef = doc(db, "users", userId);

        const unsubUser = onSnapshot(userRef, (docSnap) => {
            const data = docSnap.data();

            dispatch(setActivePet(data?.activePetId ?? null));
        });

        return () => {
            unsubPets();
            unsubUser();
        };
    }, [userId, dispatch]);
};