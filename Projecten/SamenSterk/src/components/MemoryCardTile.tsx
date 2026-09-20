import React from 'react'
import { TouchableOpacity, View } from 'react-native'
import { DifficultyLevel, DIFFICULTY_PROFILES } from '../types/shared'
import BasicText from './BasicLayoutComponents/BasicText'
import CardView from './BasicLayoutComponents/CardView'
import { MemoryCard } from '../puzzels/MemoryPuzzel/memory'


type MemoryCardProps = {
    card: MemoryCard
    difficulty: DifficultyLevel
    size: number
    onPress: (cardId: string) => void
}

const MemoryCardTile = ({ card, difficulty, size, onPress }: MemoryCardProps) => {
    const profile = DIFFICULTY_PROFILES[difficulty]
    const zichtbaar = card.isFlipped || card.isMatched
    const disabled = card.isMatched || card.isFlipped

    const label = card.isMatched
        ? `Gevonden kaart ${card.displayValue}`
        : zichtbaar
            ? `Open kaart ${card.displayValue}`
            : 'Verborgen kaart'

    const hint = card.isMatched
        ? 'Deze kaart is al gevonden'
        : zichtbaar
            ? 'Deze kaart is open'
            : 'Dubbel tik om te draaien'

    const kleur = card.isMatched
        ? 'bg-green-200 dark:bg-green-800 border-green-600'
        : zichtbaar
            ? 'bg-zinc-50 dark:bg-slate-700 border-slate-300 dark:border-slate-500'
            : profile.contrast === 'high'
                ? 'bg-slate-900 border-slate-700'
                : 'bg-zinc-300 dark:bg-slate-800 border-slate-500'

    return (
        <TouchableOpacity
            onPress={() => onPress(card.id)}
            disabled={disabled}
            accessible
            accessibilityRole="button"
            accessibilityLabel={label}
            accessibilityHint={hint}
            accessibilityState={{ disabled, selected: card.isFlipped }}
            className="m-1.5"
            style={{ width: size, height: size }}
        >
            <CardView className={`flex-1 p-0 border-2 items-center justify-center ${kleur}`}>
                <View className="items-center justify-center px-2">
                    <BasicText
                        variant="title"
                        className={`${zichtbaar ? 'text-slate-900 dark:text-slate-50' : 'text-white'}`}
                        style={{ fontSize: profile.fontSize }}
                        numberOfLines={1}
                        adjustsFontSizeToFit
                        accessibilityElementsHidden
                        importantForAccessibility="no"
                    >
                        {zichtbaar ? card.displayValue : '?'}
                    </BasicText>
                </View>
            </CardView>
        </TouchableOpacity>
    )
}

export default MemoryCardTile