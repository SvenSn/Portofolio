import { MemoryCard, MemoryScore } from './memory';
import { isMemoryPuzzleComplete } from './memoryLogic';

export function scoreMemory(
  cards: MemoryCard[],
  moves: number
): MemoryScore {
  const totalPairs = cards.length / 2;
  const matchedPairs = cards.filter(card => card.isMatched).length / 2;
  const completed = isMemoryPuzzleComplete(cards);

  const perfectMoves = totalPairs;
  const efficiencyRatio = moves > 0 ? perfectMoves / moves : 0;

  const score = completed
    ? Math.round(Math.max(0, Math.min(100, efficiencyRatio * 100)))
    : Math.round((matchedPairs / totalPairs) * 100);

  return {
    moves,
    matches: matchedPairs,
    completed,
    score,
  };
}