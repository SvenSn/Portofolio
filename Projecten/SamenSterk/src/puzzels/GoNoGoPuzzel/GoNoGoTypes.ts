export type StimulusType = 'shape' | 'color' | 'letter';
export type GoNoGoResult = 'correct_go' | 'correct_inhibit' | 'false_alarm' | 'miss';

export interface Stimulus {
  type: StimulusType;
  value: string;       // bv. 'cirkel', 'groen', 'A'
  isGo: boolean;
  displayDuration: number;   // ms dat stimulus zichtbaar is
  interTrialInterval: number; // ms pauze tussen stimuli
}

export interface GoNoGoPuzzle {
  stimuli: Stimulus[];
  totalTrials: number;
  goRatio: number;     // verhouding go vs no-go trials
}

export interface TrialResult {
  stimulus: Stimulus;
  responded: boolean;
  reactionTime: number | null;
  result: GoNoGoResult;
}

export interface GoNoGoScore {
  totalTrials: number;
  correctGo: number;        // terecht gereageerd
  correctInhibit: number;   // terecht NIET gereageerd
  falseAlarms: number;      // gereageerd op no-go
  misses: number;           // niet gereageerd op go
  avgReactionTime: number | null;
  score: number;            // 0-100
}