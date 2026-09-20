import React, { useEffect } from 'react'
import { ScrollView, View, AccessibilityInfo } from 'react-native'
import { useDispatch, useSelector } from 'react-redux'
import { StackScreenProps } from '@react-navigation/stack'

import { RootState } from '../store/store'
import { setDifficulty } from '../store/puzzelSlices/SettingsSlice'
import { DifficultyLevel } from '../types/shared'
import { PuzzelStackNavigatorParamsList } from '../navigators/types'

import BasicButton from '../components/BasicLayoutComponents/BasicButton'
import MoeilijkheidsgraadButton from '../components/MoeilijkheidsGraadButton'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import BasicText from '../components/BasicLayoutComponents/BasicText'

const OPTIONS = [
    {
        label: 'Gemakkelijk',
        value: 'easy',
        emoji: '🟢',
        omschrijving: 'Meer tijd, minder trials',
    },
    {
        label: 'Matig',
        value: 'medium',
        emoji: '🟡',
        omschrijving: 'Normaal tempo',
    },
    {
        label: 'Moeilijk',
        value: 'hard',
        emoji: '🔴',
        omschrijving: 'Snel en uitdagend',
    },
] as const

type Props = StackScreenProps<
    PuzzelStackNavigatorParamsList,
    'Moeilijkheid'
>

const MoeilijkheidsGraadScreen = ({ route, navigation }: Props) => {
    const dispatch = useDispatch()
    const { puzzle } = route.params

    const current = useSelector(
        (state: RootState) => state.settings.difficulty[puzzle]
    )

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility(
            "Kies een moeilijkheidsgraad"
        )
    }, [])

    const onSelectDifficulty = (level: DifficultyLevel, label: string) => {
        dispatch(setDifficulty({ puzzle, level }))

        AccessibilityInfo.announceForAccessibility(
            `${label} geselecteerd`
        )
    }

    const onBevestig = () => {
        AccessibilityInfo.announceForAccessibility("Start oefening")
        navigation.navigate('PuzzlePlay', { puzzle })
    }

    return (
        <BasicView className="flex-1">

            <ScrollView
                showsVerticalScrollIndicator={false}
                contentContainerClassName="px-6 pt-12 pb-6 gap-4"
            >

                <BasicView className="mb-6">

                    <BasicText
                        variant="title"
                        className="text-3xl"
                        accessibilityRole="header"
                    >
                        Moeilijkheid {"\n"} graad
                    </BasicText>

                    <BasicText
                        variant="label"
                        accessibilityLabel="Kies het niveau dat bij jou past"
                    >
                        Kies het niveau dat bij jou past
                    </BasicText>

                </BasicView>

                {OPTIONS.map(option => {
                    const isActief = current === option.value

                    return (
                        <MoeilijkheidsgraadButton
                            key={option.value}
                            emoji={option.emoji}
                            label={option.label}
                            omschrijving={option.omschrijving}
                            actief={isActief}
                            onPress={() =>
                                onSelectDifficulty(option.value, option.label)
                            }
                        />
                    )
                })}

            </ScrollView>

            <View className="px-6 pb-8 pt-2">

                <BasicButton
                    title="Bevestigen"
                    onPress={onBevestig}
                    accessibilityRole="button"
                    accessibilityLabel="Bevestig moeilijkheidsgraad"
                    accessibilityHint="Start de oefening met de gekozen moeilijkheidsgraad"
                />

            </View>

        </BasicView>
    )
}

export default MoeilijkheidsGraadScreen