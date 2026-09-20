// src/store/puzzelSlices/settingsSlice.ts

import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { DifficultyLevel } from '../../types/shared';
import {PuzzleType} from "../../types/shared"


interface SettingsState {
  difficulty: Record<PuzzleType, DifficultyLevel>;
  highContrast: boolean;
  fontSize: 'normal' | 'large' | 'xlarge';
}

const initialState: SettingsState = {
  difficulty: {
    goNoGo: 'easy',
    stroop: 'easy',
    reveal: 'easy',
  },
  highContrast: false,
  fontSize: 'normal',
};

const settingsSlice = createSlice({
  name: 'settings',
  initialState,
  reducers: {
    setDifficulty(state, action: PayloadAction<{ puzzle: PuzzleType; level: DifficultyLevel }>) {
      state.difficulty[action.payload.puzzle] = action.payload.level;
    },
    toggleHighContrast(state) {
      state.highContrast = !state.highContrast;
    },
    setFontSize(state, action: PayloadAction<SettingsState['fontSize']>) {
      state.fontSize = action.payload;
    },
  },
});

export const { setDifficulty, toggleHighContrast, setFontSize } = settingsSlice.actions;
export default settingsSlice.reducer;
export type { PuzzleType };