import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../store/store';
import { startPuzzle, submitAnswer, trialTimeout } from '../store/puzzelSlices/StroopSlice';
import { generateStroopPuzzle } from '../puzzels/StroopPuzzel/StroopGenerator';
import { StroopColor } from '../puzzels/StroopPuzzel/StroopTypes';

export const useStroop = () => {
    const dispatch = useDispatch();
    const state = useSelector((s: RootState) => s.stroop);
    const difficulty = useSelector((s: RootState) => s.settings.difficulty.stroop);

    const currentStimulus = state.puzzle?.stimuli[state.currentTrialIndex] ?? null;

    useEffect(() => {
        if (state.status !== 'showing' || !currentStimulus) return;
        const timer = setTimeout(
            () => dispatch(trialTimeout()),
            currentStimulus.timeLimit,
        );
        return () => clearTimeout(timer);
    }, [state.status, state.currentTrialIndex]);

    return {
        status: state.status,
        currentStimulus,
        score: state.score,
        trialIndex: state.currentTrialIndex,
        totalTrials: state.puzzle?.totalTrials ?? 0,
        start: () => dispatch(startPuzzle(generateStroopPuzzle(difficulty))),
        submitAnswer: (color: StroopColor) => dispatch(submitAnswer(color)),
    };
};