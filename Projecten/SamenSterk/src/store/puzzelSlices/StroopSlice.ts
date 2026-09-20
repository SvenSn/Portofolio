import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { StroopPuzzle, StroopTrialResultaat, StroopScore, StroopColor } from '../../puzzels/StroopPuzzel/StroopTypes';
import { classifyTrial, calculateScore } from '../../puzzels/StroopPuzzel/StroopScorer';

interface StroopState {
  puzzle: StroopPuzzle | null;
  currentTrialIndex: number;
  trialStartedAt: number | null;
  results: StroopTrialResultaat[];
  status: 'idle' | 'showing' | 'finished';
  score: StroopScore | null;
}

const initialState: StroopState = {
  puzzle: null,
  currentTrialIndex: 0,
  trialStartedAt: null,
  results: [],
  status: 'idle',
  score: null,
};

const stroopSlice = createSlice({
  name: 'stroop',
  initialState,
  reducers: {
    startPuzzle(state, action: PayloadAction<StroopPuzzle>) {
      if (!action.payload.stimuli.length) return;
      state.puzzle = action.payload;
      state.currentTrialIndex = 0;
      state.results = [];
      state.status = 'showing';
      state.trialStartedAt = Date.now();
      state.score = null;
    },

    stopStroopPuzzle(state) {
      state.puzzle = null;
      state.currentTrialIndex = 0;
      state.trialStartedAt = null;
      state.results = [];
      state.status = 'idle';
      state.score = null;
    },

    submitAnswer(state, action: PayloadAction<StroopColor>) {
      if (!state.puzzle) return;
      if (state.status !== 'showing') return;
      if (state.currentTrialIndex >= state.puzzle.stimuli.length) return;

      const trial = state.puzzle.stimuli[state.currentTrialIndex];
      if (!trial) return;

      const reactionTime = state.trialStartedAt
        ? Date.now() - state.trialStartedAt
        : null;

      state.results.push({
        stimulus: trial,
        answer: action.payload,
        reactionTime,
        result: classifyTrial(
          trial.correctAnswer,
          action.payload,
          trial.timeLimit,
          reactionTime
        ),
      });

      const next = state.currentTrialIndex + 1;

      if (next >= state.puzzle.stimuli.length) {
        state.status = 'finished';
        state.score = calculateScore(state.results);
        state.trialStartedAt = null;
        return;
      }

      state.currentTrialIndex = next;
      state.trialStartedAt = Date.now();
    },

    trialTimeout(state) {
      if (!state.puzzle) return;
      if (state.status !== 'showing') return;
      if (state.currentTrialIndex >= state.puzzle.stimuli.length) return;

      const trial = state.puzzle.stimuli[state.currentTrialIndex];
      if (!trial) return;

      state.results.push({
        stimulus: trial,
        answer: null,
        reactionTime: null,
        result: 'timeout',
      });

      const next = state.currentTrialIndex + 1;

      if (next >= state.puzzle.stimuli.length) {
        state.status = 'finished';
        state.score = calculateScore(state.results);
        state.trialStartedAt = null;
        return;
      }

      state.currentTrialIndex = next;
      state.trialStartedAt = Date.now();
    },
  },
});

export const {
  startPuzzle,
  stopStroopPuzzle,
  submitAnswer,
  trialTimeout,
} = stroopSlice.actions;

export default stroopSlice.reducer;