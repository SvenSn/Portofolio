import { DifficultyLevel} from '../../types/shared';
import { GoNoGoPuzzle, Stimulus, StimulusType } from './GoNoGoTypes';


const STIMULI_POOL: Record<StimulusType, { go: string[]; noGo: string[] }> = {
  shape: {
    go:   ['cirkel'],
    noGo: ['kruis', 'driehoek'],
  },
  color: {
    go:   ['groen'],
    noGo: ['rood', 'blauw'],
  },
  letter: {
    go:   ['X', 'A'],
    noGo: ['K', 'M', 'Z'],
  },
};

const DIFFICULTY_PARAMS: Record<DifficultyLevel, {
  totalTrials:        number;
  goRatio:            number;
  displayDuration:    number;
  interTrialInterval: number;
  stimulusTypes:      StimulusType[];
}> = {
  easy: {
    totalTrials:        10,
    goRatio:            0.7,
    displayDuration:    1500,
    interTrialInterval: 1000,
    stimulusTypes:      ['color'],
  },
  medium: {
    totalTrials:        20,
    goRatio:            0.5,
    displayDuration:    1000,
    interTrialInterval: 800,
    stimulusTypes:      ['color', 'shape'],
  },
  hard: {
    totalTrials:        30,
    goRatio:            0.4,
    displayDuration:    600,
    interTrialInterval: 600,
    stimulusTypes:      ['color', 'shape', 'letter'],
  },
};

// ---------------------------------------------------------------------------
// Generator
// ---------------------------------------------------------------------------

export function generateGoNoGoPuzzle(level: DifficultyLevel): GoNoGoPuzzle {
  const {
    totalTrials,
    goRatio,
    displayDuration,
    interTrialInterval,
    stimulusTypes,
  } = DIFFICULTY_PARAMS[level];

  const typeCount  = stimulusTypes.length;
  const goCount    = Math.round(totalTrials * goRatio);

  // Pre-allocate array — vermijdt herhaalde heap-reallocaties door push()
  const stimuli = new Array<Stimulus>(totalTrials);

  for (let i = 0; i < totalTrials; i++) {
    // Eerste goCount slots = go, daarna no-go → shuffle bepaalt volgorde
    const isGo   = i < goCount;
    const type   = stimulusTypes[Math.floor(Math.random() * typeCount)];
    const pool   = isGo ? STIMULI_POOL[type].go : STIMULI_POOL[type].noGo;
    const value  = pool[Math.floor(Math.random() * pool.length)];

    stimuli[i] = { type, value, isGo, displayDuration, interTrialInterval };
  }

  // Fisher-Yates in-place shuffle
  for (let i = totalTrials - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));
    const tmp   = stimuli[i];
    stimuli[i]  = stimuli[j];
    stimuli[j]  = tmp;
  }

  return { stimuli, totalTrials, goRatio };
}