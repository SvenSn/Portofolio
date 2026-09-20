import React from 'react'
import { View } from 'react-native'
import { PUZZLES } from '../data/puzzelData'
import { PuzzleType } from '../types/shared'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import BasicText from '../components/BasicLayoutComponents/BasicText'

const PuzzelDetails = ({ puzzle }: { puzzle: PuzzleType }) => {
    const puzzelData = PUZZLES.find(p => p.type === puzzle)

    if (!puzzelData) {
        return (
            <BasicView className="flex-1 justify-center items-center">
                <BasicText variant="body">
                    Puzzel niet gevonden
                </BasicText>
            </BasicView>
        )
    }

    return (
        <BasicView className="flex-1 px-6 pt-6">

            <BasicText className="text-4xl" accessibilityLabel={puzzelData.emoji}>
                {puzzelData.emoji}
            </BasicText>

            <BasicText variant="title" className="mt-4" accessibilityLabel={puzzelData.label}>
                {puzzelData.label}
            </BasicText>

            <BasicText variant="body" className="mt-4 leading-6" accessibilityLabel={puzzelData.longDescription}>
                {puzzelData.longDescription}
            </BasicText>

        </BasicView>
    )
}

export default PuzzelDetails
