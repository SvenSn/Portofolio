import { createSlice, PayloadAction, createSelector } from "@reduxjs/toolkit";
import { RootState } from "../store";
import { Pet } from "../../types";



type PetsState = {
    pets: Pet[];
    activePetId: string | null;
    isLoading: boolean;
};

const initialState: PetsState = {
    pets: [],
    activePetId: null,
    isLoading: true,
};

const petsSlice = createSlice({
    name: "pets",
    initialState,
    reducers: {
        setPets(state, action: PayloadAction<Pet[]>) {
            state.pets = action.payload;
            state.isLoading = false;
        },

        setActivePet(state, action: PayloadAction<string | null>) {
            state.activePetId = action.payload;
        },

        clearPets(state) {
            state.pets = [];
            state.activePetId = null;
            state.isLoading = true;
        },
    },
});

export const { setPets, setActivePet, clearPets } = petsSlice.actions;

export const selectPetsArray = (state: RootState) =>
    state.pets.pets;

export const selectIsLoading = (state: RootState) =>
    state.pets.isLoading;

export const selectActivePet = (state: RootState) =>
    state.pets.pets.find(
        (p) => p.id === state.pets.activePetId
    ) ?? null;

export const selectPetsSortedWithActiveFirst = createSelector(
    [
        (state: RootState) => state.pets.pets,
        (state: RootState) => state.pets.activePetId,
    ],
    (pets, activePetId) => {
        return [...pets].sort((a, b) => {
            const aActive = a.id === activePetId;
            const bActive = b.id === activePetId;

            if (aActive && !bActive) return -1;
            if (!aActive && bActive) return 1;

            return a.name.localeCompare(b.name);
        });
    }
);

export default petsSlice.reducer;
