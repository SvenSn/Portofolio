import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { RootState } from "../store";

type ColorScheme = "light" | "dark";

type SettingsState = {
    colorScheme: ColorScheme;
};

const initialState: SettingsState = {
    colorScheme: "light",
};

const settingsSlice = createSlice({
    name: "settings",
    initialState,
    reducers: {
        setColorScheme(state, action: PayloadAction<ColorScheme>) {
            state.colorScheme = action.payload;
        },
        toggleColorScheme(state) {
            state.colorScheme = state.colorScheme === "light" ? "dark" : "light";
        },
    },
});

export const { setColorScheme, toggleColorScheme } = settingsSlice.actions;

export const selectColorScheme = (state: RootState) => state.settings.colorScheme;
export const selectIsDark = (state: RootState) => state.settings.colorScheme === "dark";

export default settingsSlice.reducer;
