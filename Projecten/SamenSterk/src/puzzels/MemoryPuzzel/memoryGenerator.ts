import { DifficultyLevel, DIFFICULTY_PROFILES } from '../../types/shared';
import { MEMORY_PARAMS, MEMORY_POOL, MemoryCard, MemoryPuzzle } from './memory';

function shuffle<T>(array: T[]): T[] {
  const arr = [...array];

  for (let i = arr.length - 1; i > 0; i--) {
    const j = Math.floor(Math.random() * (i + 1));

    const temp = arr[i]!;
    arr[i] = arr[j]!;
    arr[j] = temp;
  }

  return arr;
}

export function generateMemoryPuzzle(level: DifficultyLevel): MemoryPuzzle {
  const { pairs, mode } = MEMORY_PARAMS[level];
  const profile = DIFFICULTY_PROFILES[level];
  const selectedValues = shuffle(MEMORY_POOL).slice(0, pairs);

  const cards: MemoryCard[] = [];

  for (const item of selectedValues) {
    if (mode === 'emoji') {
      cards.push(
        {
          id: `${item.key}-1`,
          pairKey: item.key,
          displayValue: item.emoji,
          contentType: 'emoji',
          isFlipped: false,
          isMatched: false,
        },
        {
          id: `${item.key}-2`,
          pairKey: item.key,
          displayValue: item.emoji,
          contentType: 'emoji',
          isFlipped: false,
          isMatched: false,
        }
      );
    } else if (mode === 'word') {
      cards.push(
        {
          id: `${item.key}-1`,
          pairKey: item.key,
          displayValue: item.word,
          contentType: 'word',
          isFlipped: false,
          isMatched: false,
        },
        {
          id: `${item.key}-2`,
          pairKey: item.key,
          displayValue: item.word,
          contentType: 'word',
          isFlipped: false,
          isMatched: false,
        }
      );
    } else {
      cards.push(
        {
          id: `${item.key}-emoji`,
          pairKey: item.key,
          displayValue: item.emoji,
          contentType: 'emoji',
          isFlipped: false,
          isMatched: false,
        },
        {
          id: `${item.key}-word`,
          pairKey: item.key,
          displayValue: item.word,
          contentType: 'word',
          isFlipped: false,
          isMatched: false,
        }
      );
    }
  }

  return {
    cards: shuffle(cards),
    totalCards: pairs * 2,
    pairs,
    mode,
    displayDuration: profile.displayDuration,
    interTrialInterval: profile.interTrialInterval,
  };
}

export function getMemoryGridColumns(totalCards: number): number {
  if (totalCards <= 4) return 2;
  if (totalCards <= 8) return 2;
  return 3;
}