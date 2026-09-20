import React from 'react'
import { FlatList, View, useWindowDimensions, ActivityIndicator } from 'react-native'
import { useMemoryPuzzle } from '../hooks/useMemoryPuzzle'
import { getMemoryGridColumns } from '../puzzels/MemoryPuzzel/memoryGenerator'
import { DifficultyLevel } from '../types/shared'
import BasicButton from './BasicLayoutComponents/BasicButton'
import BasicText from './BasicLayoutComponents/BasicText'
import CardView from './BasicLayoutComponents/CardView'
import MemoryCardTile from './MemoryCardTile'


type Props = {
    difficulty?: DifficultyLevel
}

const MemorySpel = ({ difficulty = "easy" }: Props) => {
    const { width } = useWindowDimensions()

    const {
        puzzle,
        cards,
        moves,
        score,
        loading,
        previewing,
        completed,
        onCardPress,
        resetGame
    } = useMemoryPuzzle(difficulty)

    if (loading || !puzzle) {
        return (
            <View className="flex-1 items-center justify-center">
                <ActivityIndicator accessibilityLabel="Memory laden" />
                <BasicText className="mt-3" accessibilityLiveRegion="polite">
                    Memory wordt geladen
                </BasicText>
            </View>
        )
    }

    const kolommen = getMemoryGridColumns(cards.length)

    const grootte = Math.min(
        120,
        (width - 40) / kolommen
    )

    const status = previewing
        ? "Onthoud de kaarten"
        : completed
            ? "Goed gedaan"
            : "Zoek de paren"

    return (
        <View className="flex-1 px-3">

            <CardView className="mb-3 items-center" accessible accessibilityRole="summary">
                <BasicText variant="title" accessibilityRole="header">
                    Memory
                </BasicText>

                <BasicText>Moeilijkheid: {difficulty}</BasicText>
                <BasicText>Zetten: {moves}</BasicText>
                <BasicText>Score: {score?.score ?? 0}</BasicText>

                <BasicText className="mt-2 text-sky-600" accessibilityLiveRegion="polite">
                    {status}
                </BasicText>
            </CardView>

            <FlatList
                data={cards}
                keyExtractor={(item) => item.id}
                numColumns={kolommen}
                key={kolommen}
                contentContainerStyle={{ alignItems: 'center' }}
                renderItem={({ item }) => (
                    <MemoryCardTile
                        card={item}
                        difficulty={difficulty}
                        size={grootte}
                        onPress={onCardPress}
                    />
                )}
            />

            <View className="mt-4">
                <BasicButton
                    title="Opnieuw"
                    onPress={resetGame}
                    accessibilityLabel="Start memory opnieuw"
                    accessibilityHint="Start een nieuwe ronde"
                />
            </View>

        </View>
    )
}

export default MemorySpel