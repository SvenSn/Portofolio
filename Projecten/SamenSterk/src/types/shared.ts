// src/types/shared.ts

export type DifficultyLevel = 'easy' | 'medium' | 'hard';

export interface DifficultyProfile {
  timeLimit: number;
  displayDuration: number;
  interTrialInterval: number;
  fontSize: number;
  contrast: 'high' | 'normal';
}

export const DIFFICULTY_PROFILES: Record<DifficultyLevel, DifficultyProfile> = {
  easy:   { timeLimit: 5000, displayDuration: 1500, interTrialInterval: 1000, fontSize: 32, contrast: 'high' },
  medium: { timeLimit: 3000, displayDuration: 1000, interTrialInterval: 800,  fontSize: 24, contrast: 'normal' },
  hard:   { timeLimit: 1500, displayDuration: 600,  interTrialInterval: 600,  fontSize: 18, contrast: 'normal' },
};

export type PuzzleType = 'goNoGo'| 'stroop' | 'memory';

export type ExerciseType = "arm" | "been" | "borst" | "rug" | "core" | "schouder"

export const EXERCISE_TYPES: ExerciseType[] = [
    "arm", "been", "borst", "rug", "core", "schouder"
]

export interface ExerciseStep {
    order: number;
    beschrijving: string;
    imageUrl: string;
}

export interface Exercise {
    id: string;
    name: string;
    type: ExerciseType;
    KorteBeschrijving: string;
    LangeBeschrijving: string;
    steps: ExerciseStep[];
}

export type HerhaalType = "nooit" | "dagelijks" | "wekelijks" | "maandelijks"

export interface GeplandeOefening {
    id: string
    oefeningId: string
    oefeningNaam: string
    datum: string
    herhaling: HerhaalType
    herhalingDagen: number[]
    gedaan: boolean
}