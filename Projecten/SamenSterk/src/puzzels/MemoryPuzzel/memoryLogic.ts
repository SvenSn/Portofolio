import { MemoryCard, MemorySelectionResult } from './memory';

export function showAllMemoryCards(cards: MemoryCard[]): MemoryCard[] {
  return cards.map(card => ({ ...card, isFlipped: true }));
}

export function hideAllUnmatchedMemoryCards(cards: MemoryCard[]): MemoryCard[] {
  return cards.map(card =>
    card.isMatched ? card : { ...card, isFlipped: false }
  );
}

export function flipMemoryCard(cards: MemoryCard[], cardId: string): MemoryCard[] {
  return cards.map(card =>
    card.id === cardId && !card.isMatched && !card.isFlipped
      ? { ...card, isFlipped: true }
      : card
  );
}

export function hideMemoryCards(
  cards: MemoryCard[],
  firstCardId: string,
  secondCardId: string
): MemoryCard[] {
  return cards.map(card =>
    card.id === firstCardId || card.id === secondCardId
      ? { ...card, isFlipped: false }
      : card
  );
}

export function getFlippedUnmatchedCards(cards: MemoryCard[]): MemoryCard[] {
  return cards.filter(card => card.isFlipped && !card.isMatched);
}

export function resolveMemorySelection(
  cards: MemoryCard[],
  firstCardId: string,
  secondCardId: string
): MemorySelectionResult {
  const firstCard = cards.find(card => card.id === firstCardId);
  const secondCard = cards.find(card => card.id === secondCardId);

  if (!firstCard || !secondCard || firstCard.id === secondCard.id) {
    return {
      cards,
      isMatch: false,
    };
  }

  const isMatch = firstCard.pairKey === secondCard.pairKey;

  if (!isMatch) {
    return {
      cards,
      isMatch: false,
    };
  }

  return {
    cards: cards.map(card =>
      card.pairKey === firstCard.pairKey
        ? { ...card, isMatched: true, isFlipped: true }
        : card
    ),
    isMatch: true,
  };
}

export function isMemoryPuzzleComplete(cards: MemoryCard[]): boolean {
  return cards.every(card => card.isMatched);
}
