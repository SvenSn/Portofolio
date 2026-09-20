import React, { useEffect } from 'react'
import { ScrollView, TouchableOpacity, View, AccessibilityInfo } from 'react-native'
import OefeningenList from '../components/OefeningenList'
import { useAppSelector, useAppDispatch } from '../hooks/ReduxHooks'
import { selectFilteredExercises, toggleTypeFilter } from '../store/oefeningenSlice'
import { EXERCISE_TYPES } from '../types/shared'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import CardView from '../components/BasicLayoutComponents/CardView'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicButton from '../components/BasicLayoutComponents/BasicButton'
import { useNavigation } from '@react-navigation/native'
import { useGebruiker } from '../hooks/useGebruiker'

const OefeningenScreen = () => {
    const dispatch = useAppDispatch()
    const navigation = useNavigation()

    const oefeningen = useAppSelector(selectFilteredExercises)
    const selectedTypes = useAppSelector(state => state.exercises.selectedTypes)
    const { isAdmin } = useGebruiker()

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility("Oefeningen scherm")
    }, [])

    return (
        <BasicView className="flex-1">
            <BasicView className="px-4 pt-6 pb-2 items-center">

                <BasicText
                    variant="title"
                    accessibilityRole="header"
                >
                    Filter
                </BasicText>

                <BasicText
                    accessibilityLabel={`${oefeningen.length} oefeningen gevonden`}
                >
                    {oefeningen.length} oefeningen gevonden
                </BasicText>

            </BasicView>
            {isAdmin && (
                <BasicView className="px-4 pb-2">

                    <BasicButton
                        title="Nieuwe oefening"
                        onPress={() => {
                            AccessibilityInfo.announceForAccessibility("Nieuwe oefening maken")
                            navigation.navigate("AdminOefeningScreen")
                        }}
                        accessibilityRole="button"
                        accessibilityLabel="Nieuwe oefening toevoegen"
                        accessibilityHint="Ga naar scherm om een nieuwe oefening te maken"
                    />

                </BasicView>
            )}
            <ScrollView
                horizontal
                showsHorizontalScrollIndicator={false}
                style={{ flexGrow: 0 }}
                contentContainerClassName="px-4 py-2 gap-3"
            >

                {EXERCISE_TYPES.map(type => {
                    const isSelected = selectedTypes.includes(type)

                    return (
                        <TouchableOpacity
                            key={type}
                            onPress={() => {
                                dispatch(toggleTypeFilter(type))

                                AccessibilityInfo.announceForAccessibility(
                                    isSelected
                                        ? `${type} filter verwijderd`
                                        : `${type} filter toegevoegd`
                                )
                            }}
                            activeOpacity={0.7}
                            accessibilityRole="button"
                            accessibilityLabel={`${type} filter`}
                            accessibilityState={{ selected: isSelected }}
                        >

                            <CardView
                                className={`
                                    px-4 py-2 rounded-full items-center justify-center
                                    ${isSelected
                                        ? 'bg-blue-500 border border-blue-600'
                                        : 'bg-white dark:bg-slate-800 border border-slate-200 dark:border-slate-700'
                                    }
                                `}
                            >

                                <BasicText>
                                    {type}
                                </BasicText>

                            </CardView>
                        </TouchableOpacity>
                    )
                })}

            </ScrollView>
            <OefeningenList />

        </BasicView>
    )
}

export default OefeningenScreen