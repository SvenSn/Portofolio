import { useEffect, useState } from "react";
import { collection, query, orderBy, limit, onSnapshot } from "firebase/firestore";
import { db } from "../config/firebase";
import {
    getTodayKey,
    getYesterdayKey,
    getWeekKey,
    getWeekKeyFromDateKey,
} from "../utils/stepStats";

interface StepStats {
    vandaag: number;
    gisteren: number;
    dezeWeek: number;
    afgelopen7Dagen: { date: string; steps: number }[];
    isLoading: boolean;
}

export const useStepStats = (userId: string | null): StepStats => {
    const [stats, setStats] = useState<StepStats>({
        vandaag: 0,
        gisteren: 0,
        dezeWeek: 0,
        afgelopen7Dagen: [],
        isLoading: true,
    });

    useEffect(() => {
        if (!userId) {
            setStats((prev) => ({ ...prev, isLoading: false }));
            return;
        }
        setStats((prev) => ({ ...prev, isLoading: true }));

        const q = query(
            collection(db, "users", userId, "dailySteps"),
            orderBy("date", "desc"),
            limit(14)
        );

        const unsub = onSnapshot(
            q,
            (snap) => {
                const dagen = snap.docs.map((doc) => ({
                    date: doc.data().date as string,
                    steps: doc.data().steps as number,
                    week: doc.data().week as string | undefined,
                }));

                setStats({
                    vandaag: dagen.find((d) => d.date === getTodayKey())?.steps ?? 0,
                    gisteren: dagen.find((d) => d.date === getYesterdayKey())?.steps ?? 0,
                    dezeWeek: dagen
                        .filter(
                            (d) =>
                                (d.week ?? getWeekKeyFromDateKey(d.date)) ===
                                getWeekKey()
                        )
                        .reduce((sum, d) => sum + d.steps, 0),
                    afgelopen7Dagen: dagen.slice(0, 7).reverse(),
                    isLoading: false,
                });
            },
            (error) => {
                console.error("[useStepStats] Live ophalen mislukt:", error);
                setStats((prev) => ({ ...prev, isLoading: false }));
            }
        );

        return () => unsub();
    }, [userId]);

    return stats;
};