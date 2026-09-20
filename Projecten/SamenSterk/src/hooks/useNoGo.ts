import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../store/store';
import { startPuzzle, respond, trialTimeout, nextTrial } from '../store/puzzelSlices/GoNoGoSlice';
import { generateGoNoGoPuzzle } from '../puzzels/GoNoGoPuzzel/GoNoGoGenerator';

export function useGoNoGo() {
  const dispatch = useDispatch();
  const state = useSelector((s: RootState) => s.goNoGo);
  const difficulty = useSelector((s: RootState) => s.settings.difficulty.goNoGo); 
  const currentStimulus = state.puzzle?.stimuli[state.currentTrialIndex] ?? null;

  // timer voor stimulus verbergen
  useEffect(() => {
    if (state.status !== 'showing' || !currentStimulus) return;
    const t = setTimeout(() => dispatch(trialTimeout()), currentStimulus.displayDuration);
    return () => clearTimeout(t);
  }, [state.status, state.currentTrialIndex]);

  // inter-trial interval
  useEffect(() => {
    if (state.status !== 'iti' || !currentStimulus) return;
    const t = setTimeout(() => dispatch(nextTrial()), currentStimulus.interTrialInterval);
    return () => clearTimeout(t);
  }, [state.status]);

  return {
    status: state.status,
    currentStimulus,
    score: state.score,
    trialIndex: state.currentTrialIndex,
    totalTrials: state.puzzle?.totalTrials ?? 0,
    start: () => dispatch(startPuzzle(generateGoNoGoPuzzle(difficulty))),
    respond: () => dispatch(respond()),
  };
}