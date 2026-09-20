import React, { useEffect, useMemo, useState } from 'react'
import { ActivityIndicator, ScrollView, View } from 'react-native'
import { Calendar } from 'react-native-calendars'
import { auth } from '../firebase'
import { useAppSelector } from '../hooks/ReduxHooks'
import useGeplandeOefeningen from '../hooks/useGeplandeOefeningen'
import BasicButton from '../components/BasicLayoutComponents/BasicButton'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import CardView from '../components/BasicLayoutComponents/CardView'

type ViewType = 'dag' | 'week'

const toISODate = (d: Date) => d.toISOString().split('T')[0]

const getWeekDaysFromToday = () => {
    const today = new Date()
    const day = today.getDay()
    const monday = new Date(today)
    monday.setDate(today.getDate() - (day === 0 ? 6 : day - 1))

    const days: string[] = []
    for (let i = 0; i < 7; i++) {
        const d = new Date(monday)
        d.setDate(monday.getDate() + i)
        days.push(toISODate(d))
    }
    return days
}

const KalenderScreen = () => {
    const uid = auth.currentUser!.uid
    const { haalGeplandeOefeningenOp, wisselGedaan } = useGeplandeOefeningen(uid)

    const geplandeOefeningen = useAppSelector(state => state.geplandeOefeningen.geplandeOefeningen)
    const status = useAppSelector(state => state.geplandeOefeningen.status)
    const darkMode = useAppSelector(state => state.accountSettings.darkMode)

    const todayISO = useMemo(() => toISODate(new Date()), [])
    const weekDays = useMemo(() => getWeekDaysFromToday(), [])
    const dayLabels = useMemo(() => ['Ma', 'Di', 'Wo', 'Do', 'Vr', 'Za', 'Zo'], [])

    const [gekozenDatum, setGekozenDatum] = useState(todayISO)
    const [view, setView] = useState<ViewType>('dag')

    useEffect(() => {
        haalGeplandeOefeningenOp()
    }, [])

    const oefeningenVanDag = (datum: string) =>
        geplandeOefeningen.filter(o => o.datum === datum)

    const calendarTheme = useMemo(() => ({
        backgroundColor: darkMode ? '#1e293b' : '#ffffff',
        calendarBackground: darkMode ? '#1e293b' : '#ffffff',
        dayTextColor: darkMode ? '#f8fafc' : '#1e293b',
        monthTextColor: darkMode ? '#f8fafc' : '#1e293b',
        textSectionTitleColor: darkMode ? '#94a3b8' : '#64748b',
        textDisabledColor: darkMode ? '#475569' : '#cbd5e1',
        todayTextColor: '#0284c7',
        arrowColor: '#0284c7',
        selectedDayBackgroundColor: '#0284c7',
        selectedDayTextColor: '#ffffff',
    }), [darkMode])

    const markedDates = useMemo(() => {
        const result: Record<string, any> = {}

        geplandeOefeningen.forEach(o => {
            result[o.datum] = {
                customStyles: {
                    container: {
                        backgroundColor: darkMode ? '#334155' : '#bfdbfe',
                        borderRadius: 8,
                    },
                    text: {
                        color: darkMode ? '#f8fafc' : '#1e3a8a',
                        fontWeight: '600',
                    },
                },
            }
        })

        result[gekozenDatum] = {
            customStyles: {
                container: {
                    backgroundColor: '#0284c7',
                    borderRadius: 8,
                },
                text: {
                    color: 'white',
                    fontWeight: 'bold',
                },
            },
        }

        return result
    }, [geplandeOefeningen, gekozenDatum, darkMode])

    if (status === 'loading') {
        return (
            <BasicView className="flex-1 justify-center items-center">
                <ActivityIndicator size="large" color="#0284c7" />
            </BasicView>
        )
    }

    const OefeningKaart = ({ item }: any) => (
        <CardView className="p-4 mb-2 flex-row items-center gap-4 p border border-slate-200 dark:border-slate-700">
            <View
                className={`w-9 h-9 rounded-full items-center justify-center ${item.gedaan ? 'bg-green-500' : 'bg-sky-600'
                    }`}
            >
                <BasicText className="text-white">
                    {item.gedaan ? '✓' : '○'}
                </BasicText>
            </View>

            <View className="flex-1">
                <BasicText className="font-semibold">
                    {item.oefeningNaam}
                </BasicText>
                <BasicText variant="label">
                    {item.herhaling}
                </BasicText>
            </View>

            <BasicButton
                title={item.gedaan ? 'Gedaan' : 'Markeer'}
                onPress={() => wisselGedaan(item.id, !item.gedaan)}
            />
        </CardView>
    )

    const TodayDot = ({ label }: { label: string }) => (
        <View className="w-11 h-11 items-center justify-center">
            <View className="absolute w-11 h-11 rounded-full border-2 border-sky-300 dark:border-sky-500" />
            <View className="w-10 h-10 rounded-full bg-sky-600 border-2 border-sky-700 items-center justify-center">
                <BasicText className="text-white text-xs font-bold">
                    {label}
                </BasicText>
            </View>
        </View>
    )

    const NormalDot = ({ label }: { label: string }) => (
        <View className="w-10 h-10 rounded-full bg-slate-100 dark:bg-slate-700 border border-slate-200 dark:border-slate-600 items-center justify-center">
            <BasicText className="text-slate-700 dark:text-slate-200 text-xs font-semibold">
                {label}
            </BasicText>
        </View>
    )

    return (
        <BasicView className="flex-1 py-4">
            <CardView className="flex-row p-4 gap-3">
                <View className="flex-1">
                    <BasicButton title="Dag" onPress={() => setView('dag')} />
                </View>
                <View className="flex-1">
                    <BasicButton title="Week" onPress={() => setView('week')} />
                </View>
            </CardView>

            {view === 'dag' ? (
                <ScrollView
                    className="flex-1 py-4"
                    showsVerticalScrollIndicator={false}
                    contentContainerClassName="pb-10"
                >
                    <CardView className="overflow-hidden border border-slate-200 dark:border-slate-700">
                        <Calendar
                            markingType="custom"
                            onDayPress={(day) => setGekozenDatum(day.dateString)}
                            markedDates={markedDates}
                            theme={calendarTheme}
                        />
                    </CardView>

                    <BasicView className="p-4 gap-3">
                        <BasicText variant="title">
                            {oefeningenVanDag(gekozenDatum).length > 0
                                ? `${oefeningenVanDag(gekozenDatum).length} oefening(en) gepland`
                                : 'Geen oefeningen gepland'}
                        </BasicText>

                        {oefeningenVanDag(gekozenDatum).map(item => (
                            <OefeningKaart key={item.id} item={item} />
                        ))}
                    </BasicView>
                </ScrollView>
            ) : (
                <ScrollView
                    className="flex-1 p-4"
                    showsVerticalScrollIndicator={false}
                    contentContainerClassName="pb-10"
                >
                    {weekDays.map((datum, index) => {
                        const isToday = datum === todayISO
                        const items = oefeningenVanDag(datum)

                        return (
                            <View key={datum} className="mb-5">

                                <View className="flex-row items-center gap-3 mb-2">

                                    {isToday ? (
                                        <View className="w-11 h-11 items-center justify-center">
                                            <View className="absolute w-11 h-11 rounded-full border-2 border-sky-400 dark:border-sky-500" />
                                            <View className="w-10 h-10 rounded-full bg-sky-600 border-2 border-sky-700 items-center justify-center">
                                                <BasicText className="text-white text-sm font-bold">
                                                    {dayLabels[index]}
                                                </BasicText>
                                            </View>
                                        </View>
                                    ) : (
                                        <View className="w-10 h-10 rounded-full bg-slate-200 dark:bg-slate-700 border border-slate-300 dark:border-slate-600 items-center justify-center">
                                            <BasicText className="text-slate-700 dark:text-slate-200 text-sm font-semibold">
                                                {dayLabels[index]}
                                            </BasicText>
                                        </View>
                                    )}

                                    <BasicText className="text-base font-medium">
                                        {datum}
                                    </BasicText>

                                </View>

                                {items.length === 0 ? (
                                    <CardView className="p-4 border border-slate-200 dark:border-slate-700">
                                        <BasicText variant="label">
                                            Geen oefeningen
                                        </BasicText>
                                    </CardView>
                                ) : (
                                    items.map(item => (
                                        <OefeningKaart key={item.id} item={item} />
                                    ))
                                )}

                            </View>
                        )
                    })}
                </ScrollView>

            )}
        </BasicView>
    )
}

export default KalenderScreen