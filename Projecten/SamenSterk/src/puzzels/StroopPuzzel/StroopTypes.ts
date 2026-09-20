export type StroopColor = 'red' | 'blue' | 'green' | 'yellow';

export interface StroopStimulus {
    word: StroopColor;
    color: StroopColor;
    isCongruent: boolean;
    correctAnswer: StroopColor;
    timeLimit: number;
}

export interface StroopPuzzle {
    stimuli: StroopStimulus[];
    totalTrials: number;
}

export type StroopTrialResult = 'correct' | 'wrong' | 'timeout';

export interface StroopTrialResultaat {
    stimulus: StroopStimulus;
    answer: StroopColor | null;
    reactionTime: number | null;
    result: StroopTrialResult;
}

export interface StroopScore {
    totalTrials: number;
    correct: number;
    wrong: number;
    timeout: number;
    avgReactionTime: number | null;
    score: number;
}