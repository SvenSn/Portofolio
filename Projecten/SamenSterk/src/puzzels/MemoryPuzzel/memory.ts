import { DifficultyLevel } from '../../types/shared';

export type MemoryMode = 'emoji' | 'word' | 'mixed';
export type MemoryContentType = 'emoji' | 'word';

export type MemoryBaseValue = {
  key: string;
  emoji: string;
  word: string;
};

export type MemoryCard = {
  id: string;
  pairKey: string;
  displayValue: string;
  contentType: MemoryContentType;
  isFlipped: boolean;
  isMatched: boolean;
};

export type MemoryPuzzle = {
  cards: MemoryCard[];
  totalCards: number;
  pairs: number;
  mode: MemoryMode;
  displayDuration: number;
  interTrialInterval: number;
};

export type MemorySelectionResult = {
  cards: MemoryCard[];
  isMatch: boolean;
};

export type MemoryScore = {
  moves: number;
  matches: number;
  completed: boolean;
  score: number;
};

export type MemoryParams = {
  pairs: number;
  mode: MemoryMode;
};

export const MEMORY_POOL: MemoryBaseValue[] = [
  { key: 'appel', emoji: '🍎', word: 'appel' },
  { key: 'hond', emoji: '🐶', word: 'hond' },
  { key: 'auto', emoji: '🚗', word: 'auto' },
  { key: 'boom', emoji: '🌳', word: 'boom' },
  { key: 'ster', emoji: '⭐', word: 'ster' },
  { key: 'huis', emoji: '🏠', word: 'huis' },
  { key: 'kat', emoji: '🐱', word: 'kat' },
  { key: 'banaan', emoji: '🍌', word: 'banaan' },
  { key: 'zon', emoji: '☀️', word: 'zon' },
  { key: 'vis', emoji: '🐟', word: 'vis' },
  { key: 'fiets', emoji: '🚲', word: 'fiets' },
  { key: 'boek', emoji: '📘', word: 'boek' },
];

export const MEMORY_PARAMS: Record<DifficultyLevel, MemoryParams> = {
  easy: {
    pairs: 2,
    mode: 'emoji',
  },
  medium: {
    pairs: 4,
    mode: 'word',
  },
  hard: {
    pairs: 6,
    mode: 'mixed',
  },
};