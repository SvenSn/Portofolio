import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { GoNoGoPuzzle, TrialResult, GoNoGoScore } from '../../puzzels/GoNoGoPuzzel/GoNoGoTypes';
import { scoreTrials, classifyTrial } from '../../puzzels/GoNoGoPuzzel/GoNoGoScoring';

interface GoNoGoState {
  puzzle: GoNoGoPuzzle | null;
  currentTrialIndex: number;
  trialStartedAt: number | null;
  results: TrialResult[];
  status: 'idle' | 'showing' | 'iti' | 'finished';
  score: GoNoGoScore | null;
}

const initialState: GoNoGoState = {
  puzzle: null,
  currentTrialIndex: 0,
  trialStartedAt: null,
  results: [],
  status: 'idle',
  score: null,
};

const goNoGoSlice = createSlice({
  name: 'goNoGo',
  initialState,
  reducers: {
    startPuzzle(state, action: PayloadAction<GoNoGoPuzzle>) {
      if (!action.payload.stimuli.length) return;
      state.puzzle = action.payload;
      state.currentTrialIndex = 0;
      state.results = [];
      state.status = 'showing';
      state.trialStartedAt = Date.now();
      state.score = null;
    },
    
    stopGoNoGoPuzzle(state) {
      state.puzzle = null;
      state.currentTrialIndex = 0;
      state.trialStartedAt = null;
      state.results = [];
      state.status = 'idle';
      state.score = null;
    },

    respond(state) {
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
        responded: true,
        reactionTime,
        result: classifyTrial(trial.isGo, true, reactionTime, trial.displayDuration),
      });

      state.status = 'iti';
    },

    trialTimeout(state) {
      if (!state.puzzle) return;
      if (state.status !== 'showing') return;
      if (state.currentTrialIndex >= state.puzzle.stimuli.length) return;

      const trial = state.puzzle.stimuli[state.currentTrialIndex];
      if (!trial) return;

      state.results.push({
        stimulus: trial,
        responded: false,
        reactionTime: null,
        result: classifyTrial(trial.isGo, false, null, trial.displayDuration),
      });

      state.status = 'iti';
    },

    nextTrial(state) {
      if (!state.puzzle) return;

      const next = state.currentTrialIndex + 1;

      if (next >= state.puzzle.stimuli.length) {
        state.status = 'finished';
        state.score = scoreTrials(state.results);
        state.trialStartedAt = null;
        return;
      }

      state.currentTrialIndex = next;
      state.status = 'showing';
      state.trialStartedAt = Date.now();
    },
  },
});

export const {
  startPuzzle,
  stopGoNoGoPuzzle,
  respond,
  trialTimeout,
  nextTrial,
} = goNoGoSlice.actions;

export default goNoGoSlice.reducer;