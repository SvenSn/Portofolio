import React, { createContext, useContext, useEffect, useRef, useState } from "react";
import { Pedometer } from "expo-sensors";
import { useActivePet } from "../hooks/useActivePet";
import { syncStepsToFirestore } from "../utils/syncStepsToFirestore";

type PedometerContextValue = {
    pendingSteps: number;
    isSyncing: boolean;
    isAvailable: boolean;
};

const PedometerContext = createContext<PedometerContextValue>({
    pendingSteps: 0,
    isSyncing: false,
    isAvailable: false,
});

export const PedometerProvider = ({
    userId,
    children,
}: {
    userId: string | null;
    children: React.ReactNode;
}) => {
    const activePet = useActivePet();

    const [pendingSteps, setPendingSteps] = useState(0);
    const [isSyncing, setIsSyncing] = useState(false);
    const [isAvailable, setIsAvailable] = useState(false);

    const pendingRef = useRef(0);
    const syncingRef = useRef(false);
    const lastStepsRef = useRef(0);
    const activePetRef = useRef(activePet); 

    useEffect(() => { pendingRef.current = pendingSteps; }, [pendingSteps]);
    useEffect(() => { activePetRef.current = activePet; }, [activePet]);

    // Pedometer starten
    useEffect(() => {
        if (!userId) return;
        let sub: ReturnType<typeof Pedometer.watchStepCount> | undefined;

        (async () => {
            const { status } = await Pedometer.requestPermissionsAsync();
            if (status !== "granted") return;

            const available = await Pedometer.isAvailableAsync();
            setIsAvailable(available);
            if (!available) return;

            sub = Pedometer.watchStepCount(({ steps }) => {
                const diff = steps - lastStepsRef.current;
                lastStepsRef.current = steps;
                if (diff > 0) setPendingSteps((p) => p + diff);
            });
        })();

        return () => sub?.remove();
    }, [userId]);

    // Sync elke 10 seconden
    useEffect(() => {
        if (!userId) return;

        const interval = setInterval(async () => {
            const pet = activePetRef.current;
            if (syncingRef.current || pendingRef.current <= 0 || !pet) return;

            const steps = pendingRef.current;
            syncingRef.current = true;
            setIsSyncing(true);

            try {
                await syncStepsToFirestore(userId, pet, steps);
                setPendingSteps(0);
            } catch (e) {
                console.error("[Pedometer] Sync mislukt:", e);
            } finally {
                syncingRef.current = false;
                setIsSyncing(false);
            }
        }, 10_000);

        return () => clearInterval(interval);
    }, [userId]);

    return (
        <PedometerContext.Provider value={{ pendingSteps, isSyncing, isAvailable }}>
            {children}
        </PedometerContext.Provider>
    );
};

export const usePedometerContext = () => useContext(PedometerContext);