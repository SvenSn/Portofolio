import { createSelector, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Exercise, ExerciseType } from '../types/shared';
import { RootState } from './store';

interface ExerciseState {
  exercises: Exercise[];
  selectedTypes: ExerciseType[];
  status: 'idle' | 'loading' | 'error';
}

const initialState: ExerciseState = {
  exercises: [],
  selectedTypes: [],
  status: 'idle',
};

const exerciseSlice = createSlice({
  name: 'exercises',
  initialState,
  reducers: {
    setExercises: (state, action: PayloadAction<Exercise[]>) => {
      state.exercises = action.payload;
      state.status = 'idle';
    },
    setLoading: (state) => {
      state.status = 'loading';
    },
    setError: (state) => {
      state.status = 'error';
    },
    toggleTypeFilter(state, action: PayloadAction<ExerciseType>) {
      const type = action.payload;
      if (state.selectedTypes.includes(type)) {
        state.selectedTypes = state.selectedTypes.filter(t => t !== type);
      } else {
        state.selectedTypes.push(type);
      }
    },
    clearFilters(state) {
      state.selectedTypes = [];
    }
  }
});

export const selectFilteredExercises = createSelector(
  (state: RootState) => state.exercises.exercises,
  (state: RootState) => state.exercises.selectedTypes,
  (exercises, selectedTypes) => {
    if (selectedTypes.length === 0) return exercises;
    return exercises.filter(e => selectedTypes.includes(e.type));
  }
);

export const {
  setExercises,
  setLoading,
  setError,
  toggleTypeFilter,
  clearFilters
} = exerciseSlice.actions;

export default exerciseSlice.reducer;