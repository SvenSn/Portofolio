import { useCallback, useEffect, useRef, useState } from 'react'
import { DifficultyLevel } from '../types/shared'
import type { MemoryCard, MemoryPuzzle, MemoryScore } from '../puzzels/MemoryPuzzel/memory'
import { generateMemoryPuzzle } from '../puzzels/MemoryPuzzel/memoryGenerator'
import {
  flipMemoryCard,
  getFlippedUnmatchedCards,
  hideAllUnmatchedMemoryCards,
  hideMemoryCards,
  isMemoryPuzzleComplete,
  resolveMemorySelection,
  showAllMemoryCards,
} from '../puzzels/MemoryPuzzel/memoryLogic'
import { scoreMemory } from '../puzzels/MemoryPuzzel/memoryScoring'

export type UseMemoryPuzzleReturn = {
  puzzle: MemoryPuzzle | null
  cards: MemoryCard[]
  moves: number
  score: MemoryScore | null
  loading: boolean
  previewing: boolean
  busy: boolean
  completed: boolean
  onCardPress: (cardId: string) => void
  resetGame: () => void
}

// hoe lang de kaarten initieel getoond worden
const PREVIEW_DELAY: Record<DifficultyLevel, number> = {
  easy: 2500,
  medium: 2000,
  hard: 1700,
}

// hoe lang verkeerd kaarten terug omdraaien 
const FLIP_DELAY: Record<DifficultyLevel, number> = {
  easy: 1500,
  medium: 1300,
  hard: 1200,
}

export function useMemoryPuzzle(
  difficulty: DifficultyLevel
): UseMemoryPuzzleReturn {
  const [puzzle, setPuzzle] = useState<MemoryPuzzle | null>(null)
  const [cards, setCards] = useState<MemoryCard[]>([])
  const [moves, setMoves] = useState(0)
  const [score, setScore] = useState<MemoryScore | null>(null)
  const [loading, setLoading] = useState(true)
  const [previewing, setPreviewing] = useState(true)
  const [busy, setBusy] = useState(false)
  const [completed, setCompleted] = useState(false)

  const previewTimeoutRef = useRef<ReturnType<typeof setTimeout> | null>(null)
  const hideTimeoutRef = useRef<ReturnType<typeof setTimeout> | null>(null)

  const clearTimers = useCallback(() => {
    if (previewTimeoutRef.current) {
      clearTimeout(previewTimeoutRef.current)
      previewTimeoutRef.current = null
    }

    if (hideTimeoutRef.current) {
      clearTimeout(hideTimeoutRef.current)
      hideTimeoutRef.current = null
    }
  }, [])

  const initGame = useCallback(() => {
    clearTimers()

    const nextPuzzle = generateMemoryPuzzle(difficulty)
    const previewCards = showAllMemoryCards(nextPuzzle.cards)

    setPuzzle(nextPuzzle)
    setCards(previewCards)
    setMoves(0)
    setScore(null)
    setLoading(false)
    setBusy(false)
    setCompleted(false)
    setPreviewing(true)

    previewTimeoutRef.current = setTimeout(() => {
      setCards(prev => hideAllUnmatchedMemoryCards(prev))
      setPreviewing(false)
    }, PREVIEW_DELAY[difficulty])
  }, [clearTimers, difficulty])

  useEffect(() => {
    initGame()

    return () => {
      clearTimers()
    }
  }, [initGame, clearTimers])

  useEffect(() => {
    setScore(scoreMemory(cards, moves))
    setCompleted(cards.length > 0 && isMemoryPuzzleComplete(cards))
  }, [cards, moves])

  const onCardPress = useCallback((cardId: string) => {
    if (previewing || busy || !puzzle) return

    setCards(prevCards => {
      const pressedCard = prevCards.find(card => card.id === cardId)

      if (!pressedCard || pressedCard.isFlipped || pressedCard.isMatched) {
        return prevCards
      }

      const flippedCards = flipMemoryCard(prevCards, cardId)
      const selectedCards = getFlippedUnmatchedCards(flippedCards)

      if (selectedCards.length < 2) {
        return flippedCards
      }

      const [firstCard, secondCard] = selectedCards

      setBusy(true)
      setMoves(prev => prev + 1)

      const result = resolveMemorySelection(
        flippedCards,
        firstCard!.id,
        secondCard!.id
      )

      if (result.isMatch) {
        setBusy(false)
        return result.cards
      }

      hideTimeoutRef.current = setTimeout(() => {
        setCards(currentCards =>
          hideMemoryCards(
            currentCards,
            firstCard!.id,
            secondCard!.id
          )
        )
        setBusy(false)
      }, FLIP_DELAY[difficulty])

      return flippedCards
    })
  }, [busy, previewing, puzzle, difficulty])

  const resetGame = useCallback(() => {
    initGame()
  }, [initGame])

  return {
    puzzle,
    cards,
    moves,
    score,
    loading,
    previewing,
    busy,
    completed,
    onCardPress,
    resetGame,
  }
}