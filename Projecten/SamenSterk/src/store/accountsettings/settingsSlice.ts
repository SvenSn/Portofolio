import { createSlice, PayloadAction } from '@reduxjs/toolkit';

type TextSize = 'normal' | 'large';

type SettingsState = {
    darkMode: boolean;
    textSize: TextSize;
};

const initialState: SettingsState = {
    darkMode: false,
    textSize: 'normal',
};

const settingsSlice = createSlice({
    name: 'accountSettings',
    initialState,
    reducers: {
        setDarkMode(state,action : PayloadAction<boolean>) {
            state.darkMode = action.payload;
        },
        setTextSize(state, action: PayloadAction<TextSize>) {
            state.textSize = action.payload;
        },
        setSettings(state, action: PayloadAction<SettingsState>) {
            return action.payload;
        },
    },
});

export const { setDarkMode, setTextSize, setSettings } = settingsSlice.actions;
export default settingsSlice.reducer;