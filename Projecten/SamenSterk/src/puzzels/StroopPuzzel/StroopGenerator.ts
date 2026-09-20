import { DifficultyLevel } from '../../types/shared';
import { StroopPuzzle, StroopStimulus, StroopColor } from './StroopTypes';

const COLORS: StroopColor[] = ['red', 'blue', 'green', 'yellow'];
const COLOR_COUNT = COLORS.length; // 4 — constant, buiten loops

const INCONGRUENT_OPTIONS: Record<StroopColor, StroopColor[]> = {
  red:    COLORS.filter(c => c !== 'red')    as StroopColor[],
  blue:   COLORS.filter(c => c !== 'blue')   as StroopColor[],
  green:  COLORS.filter(c => c !== 'green')  as StroopColor[],
  yellow: COLORS.filter(c => c !== 'yellow') as StroopColor[],
};

const DIFFICULTY_PARAMS: Record<DifficultyLevel, {
  totalTrials:       number;
  incongruentRatio:  number;
  timeLimit:         number;
}> = {
  easy:   { totalTrials: 10, incongruentRatio: 0.3, timeLimit: 4000 },
  medium: { totalTrials: 20, incongruentRatio: 0.5, timeLimit: 2500 },
  hard:   { totalTrials: 30, incongruentRatio: 0.7, timeLimit: 1500 },
};


export function generateStroopPuzzle(level: DifficultyLevel): StroopPuzzle {
  const { totalTrials, incongruentRatio, timeLimit } = DIFFICULTY_PARAMS[level];

  const congruentCount = Math.round(totalTrials * (1 - incongruentRatio));
  const stimuli        = new Array<StroopStimulus>(totalTrials);

  for (let i = 0; i < totalTrials; i++) {
    const isCongruent = i < congruentCount;
    const word        = COLORS[Math.floor(Math.random() * COLOR_COUNT)];
    const options     = isCongruent ? null : INCONGRUENT_OPTIONS[word];
    const color       = isCongruent
      ? word
      : options![Math.floor(Math.random() * 3)]; // incongruent pool is altijd 3

    stimuli[i] = { word, color, isCongruent, correctAnswer: color, timeLimit };
  }

  for (let i = totalTrials - 1; i > 0; i--) {
    const j      = Math.floor(Math.random() * (i + 1));
    const tmp    = stimuli[i];
    stimuli[i]   = stimuli[j];
    stimuli[j]   = tmp;
  }

  return { stimuli, totalTrials };
}