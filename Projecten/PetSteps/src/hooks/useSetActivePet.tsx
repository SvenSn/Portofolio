import { useCallback } from "react";
import { useAppDispatch } from "./ReduxHooks";
import { setActivePet as setActivePetAction } from "../store/pets/petSlice";
import { setActivePet as persistActivePet } from "../utils/pets/setActivePet";

export const useSetActivePet = () => {
    const dispatch = useAppDispatch();

    const setActivePet = useCallback(
        async (userId: string, petId: string) => {
            if (!userId || !petId) return;

            dispatch(setActivePetAction(petId));
            await persistActivePet(userId, petId);
        },
        [dispatch]
    );

    return { setActivePet };
};
