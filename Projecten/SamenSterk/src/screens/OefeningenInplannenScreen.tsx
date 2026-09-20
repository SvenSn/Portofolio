import React, { useEffect, useMemo, useState } from 'react'
import { ScrollView, TouchableOpacity, Alert, View, AccessibilityInfo } from 'react-native'
import { Calendar } from 'react-native-calendars'
import { useRoute, useNavigation } from '@react-navigation/native'
import { auth } from "../firebase"
import { OefeningenStackNavProps } from '../navigators/types'
import useGeplandeOefeningen from '../hooks/useGeplandeOefeningen'
import { HerhaalType } from '../types/shared'
import BasicButton from '../components/BasicLayoutComponents/BasicButton'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import CardView from '../components/BasicLayoutComponents/CardView'

const HERHAAL_OPTIES: HerhaalType[] = ['nooit', 'dagelijks', 'wekelijks', 'maandelijks']

const DAGEN = [
    { label: 'Ma', value: 1 },
    { label: 'Di', value: 2 },
    { label: 'Wo', value: 3 },
    { label: 'Do', value: 4 },
    { label: 'Vr', value: 5 },
    { label: 'Za', value: 6 },
    { label: 'Zo', value: 0 },
]

const OefeningInplannenScreen = () => {

    const { params: { data } } = useRoute<OefeningenStackNavProps<"OefeningenInplannen">["route"]>()
    const navigation = useNavigation()
    const uid = auth.currentUser!.uid
    const { voegOefeningToe } = useGeplandeOefeningen(uid)

    const [gekozenDatum, setGekozenDatum] = useState('')
    const [herhaling, setHerhaling] = useState<HerhaalType>('nooit')
    const [herhalingDagen, setHerhalingDagen] = useState<number[]>([])

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility(
            `Oefening ${data.name ?? "oefening"} inplannen`
        )
    }, [])

    const wisselDag = (dag: number) => {
        const nieuw = herhalingDagen.includes(dag)
            ? herhalingDagen.filter(d => d !== dag)
            : [...herhalingDagen, dag]

        setHerhalingDagen(nieuw)

        AccessibilityInfo.announceForAccessibility(
            nieuw.includes(dag)
                ? `Dag geselecteerd`
                : `Dag gedeselecteerd`
        )
    }

    const handleOpslaan = async () => {
        if (!gekozenDatum) {
            Alert.alert('Kies een datum')
            AccessibilityInfo.announceForAccessibility("Geen datum gekozen")
            return
        }

        await voegOefeningToe({
            oefeningId: data.id,
            oefeningNaam: data.name,
            datum: gekozenDatum,
            herhaling,
            herhalingDagen,
            gedaan: false,
        })

        AccessibilityInfo.announceForAccessibility("Oefening opgeslagen")

        navigation.goBack()
    }

    return (
        <ScrollView className="flex-1">
            <BasicView className="p-4 gap-6">

                <BasicView>

                    <BasicText
                        variant="title"
                        accessibilityRole="header"
                    >
                        {data.name ?? "Oefening"} inplannen
                    </BasicText>

                    <BasicText
                        accessibilityLabel="Kies een datum en herhaling"
                    >
                        Kies een datum en herhaling
                    </BasicText>

                </BasicView>

                <CardView className="overflow-hidden border border-slate-200 dark:border-slate-700">
                    <Calendar
                        onDayPress={(day) => {
                            setGekozenDatum(day.dateString)

                            AccessibilityInfo.announceForAccessibility(
                                `Datum geselecteerd ${day.dateString}`
                            )
                        }}
                    />
                </CardView>

                {gekozenDatum !== '' && (
                    <BasicText
                        accessibilityLabel={`Gekozen datum ${gekozenDatum}`}
                    >
                        Gekozen datum: {gekozenDatum}
                    </BasicText>
                )}

                <CardView className="p-4 gap-3 border border-slate-200 dark:border-slate-700">

                    <BasicText accessibilityRole="header">
                        Herhaling
                    </BasicText>

                    <View className="flex-row flex-wrap gap-2">

                        {HERHAAL_OPTIES.map(optie => {
                            const isSelected = herhaling === optie

                            return (
                                <TouchableOpacity
                                    key={optie}
                                    onPress={() => {
                                        setHerhaling(optie)
                                        AccessibilityInfo.announceForAccessibility(`${optie} geselecteerd`)
                                    }}
                                    accessibilityRole="button"
                                    accessibilityLabel={`${optie} herhaling`}
                                    accessibilityState={{ selected: isSelected }}
                                >
                                    <CardView className="px-4 py-2 rounded-full">

                                        <BasicText>
                                            {optie}
                                        </BasicText>

                                    </CardView>
                                </TouchableOpacity>
                            )
                        })}

                    </View>

                </CardView>

                {herhaling === 'wekelijks' && (
                    <CardView className="p-4 gap-3">

                        <BasicText accessibilityRole="header">
                            Dagen
                        </BasicText>

                        <View className="flex-row gap-3 justify-between">

                            {DAGEN.map(dag => {
                                const isSelected = herhalingDagen.includes(dag.value)

                                return (
                                    <TouchableOpacity
                                        key={dag.value}
                                        onPress={() => wisselDag(dag.value)}
                                        accessibilityRole="button"
                                        accessibilityLabel={`Selecteer ${dag.label}`}
                                        accessibilityState={{ selected: isSelected }}
                                    >
                                        <View className="w-12 h-12 items-center justify-center">
                                            <BasicText>
                                                {dag.label}
                                            </BasicText>
                                        </View>
                                    </TouchableOpacity>
                                )
                            })}

                        </View>

                    </CardView>
                )}

                <BasicButton
                    onPress={handleOpslaan}
                    title="Opslaan"
                    accessibilityRole="button"
                    accessibilityLabel="Oefening opslaan"
                    accessibilityHint="Sla deze planning op"
                />

            </BasicView>
        </ScrollView>
    )
}

export default OefeningInplannenScreen