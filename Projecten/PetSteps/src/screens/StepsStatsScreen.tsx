import React from 'react'
import { ActivityIndicator, ScrollView, View } from 'react-native'
import { usePedometerContext } from '../providers/PedometerProvider'
import { useStepStats } from '../hooks/useStepStats'
import { auth } from '../config/firebase'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import Card from '../components/BasicLayoutComponents/Card'
import { fromDateKey, getTodayKey } from '../utils/stepStats'

const DAILY_GOAL = 10000;

const StepsStatsScreen = () => {
    const userId = auth.currentUser?.uid
    if (!userId) return null

    const { pendingSteps, isSyncing, isAvailable } = usePedometerContext()
    const { vandaag, gisteren, dezeWeek, afgelopen7Dagen, isLoading } =
        useStepStats(userId)

    if (isLoading) {
        return (
            <BasicView className="items-center justify-center">
                <ActivityIndicator size="large" />
                <BasicText variant="caption" className="mt-3">
                    Loading your steps...
                </BasicText>
            </BasicView>
        )
    }

    const vandaagLive = vandaag + pendingSteps
    const weekLive = dezeWeek + pendingSteps
    const max = Math.max(...afgelopen7Dagen.map((d) => d.steps), 1)
    const today = getTodayKey()
    const goalProgress = Math.min(vandaagLive / DAILY_GOAL, 1)

    return (
        <BasicView>
            <ScrollView
                className="flex-1"
                showsVerticalScrollIndicator={false}
            >
                <View className="px-5 pt-8 pb-14 gap-5">

                    <View className="gap-1">
                        <BasicText variant="secondary">
                            Keep moving to level up your cat.
                        </BasicText>
                    </View>

                    {!isAvailable && (
                        <Card className="bg-amber-50 dark:bg-amber-950 border-amber-200 dark:border-amber-800">
                            <BasicText variant="caption" className="text-amber-700 dark:text-amber-300">
                                Step tracking is not available on this device.
                            </BasicText>
                        </Card>
                    )}

                    <Card className="gap-4">
                        <View className="flex-row items-center justify-between">
                            <BasicText variant="caption">
                                Today
                            </BasicText>

                            <View className="rounded-full bg-sky-100 dark:bg-sky-950 px-3 py-1">
                                <BasicText variant="caption" className="text-sky-600 dark:text-sky-300 font-semibold">
                                    Live
                                </BasicText>
                            </View>
                        </View>

                        <View>
                            <BasicText variant="heading" className="text-5xl">
                                {vandaagLive.toLocaleString('en-GB')}
                            </BasicText>

                            <BasicText variant="caption">
                                steps today
                            </BasicText>
                        </View>

                        <View className="gap-2">
                            <View className="flex-row justify-between">
                                <BasicText variant="caption">
                                    Daily goal
                                </BasicText>

                                <BasicText variant="caption">
                                    {Math.round(goalProgress * 100)}%
                                </BasicText>
                            </View>

                            <View className="h-3 rounded-full bg-neutral-200 dark:bg-neutral-800 overflow-hidden">
                                <View
                                    style={{ width: `${goalProgress * 100}%` }}
                                    className="h-full rounded-full bg-sky-500 dark:bg-sky-400"
                                />
                            </View>

                            <BasicText variant="caption">
                                Goal: {DAILY_GOAL.toLocaleString('en-GB')} steps
                            </BasicText>
                        </View>

                        {(pendingSteps > 0 || isSyncing) && (
                            <View className="rounded-xl bg-neutral-100 dark:bg-neutral-800 px-4 py-3">
                                {pendingSteps > 0 && (
                                    <BasicText variant="caption">
                                        +{pendingSteps.toLocaleString('en-GB')} steps waiting to sync
                                    </BasicText>
                                )}

                                {isSyncing && (
                                    <BasicText variant="caption">
                                        Syncing your latest steps...
                                    </BasicText>
                                )}
                            </View>
                        )}
                    </Card>

                    <View className="flex-row gap-3">
                        <Card className="flex-1 gap-1">
                            <BasicText variant="caption">
                                Yesterday
                            </BasicText>

                            <BasicText variant="heading" className="text-2xl">
                                {gisteren.toLocaleString('en-GB')}
                            </BasicText>

                            <BasicText variant="caption">
                                steps
                            </BasicText>
                        </Card>

                        <Card className="flex-1 gap-1">
                            <BasicText variant="caption">
                                This Week
                            </BasicText>

                            <BasicText variant="heading" className="text-2xl">
                                {weekLive.toLocaleString('en-GB')}
                            </BasicText>

                            <BasicText variant="caption">
                                steps
                            </BasicText>
                        </Card>
                    </View>

                    <View className="gap-3">
                        <View className="flex-row items-center justify-between">
                            <BasicText variant="label">
                                Last 7 Days
                            </BasicText>

                            <BasicText variant="caption">
                                Activity overview
                            </BasicText>
                        </View>

                        <Card>
                            <View className="h-36 flex-row items-end gap-2">
                                {afgelopen7Dagen.map((d) => {
                                    const pct = d.steps / max
                                    const isToday = d.date === today
                                    const label = fromDateKey(d.date)
                                        .toLocaleDateString('en-GB', { weekday: 'short' })
                                        .slice(0, 2)

                                    return (
                                        <View
                                            key={d.date}
                                            className="h-full flex-1 items-center justify-end gap-2"
                                        >
                                            <View className="h-28 w-full justify-end overflow-hidden rounded-full bg-neutral-200 dark:bg-neutral-800">
                                                <View
                                                    style={{
                                                        height: `${Math.max(pct * 100, 8)}%`,
                                                    }}
                                                    className={
                                                        isToday
                                                            ? 'w-full rounded-full bg-sky-500 dark:bg-sky-400'
                                                            : 'w-full rounded-full bg-neutral-400 dark:bg-neutral-600'
                                                    }
                                                />
                                            </View>

                                            <BasicText
                                                variant="caption"
                                                className={
                                                    isToday
                                                        ? 'font-semibold text-sky-500 dark:text-sky-400'
                                                        : ''
                                                }
                                            >
                                                {label}
                                            </BasicText>
                                        </View>
                                    )
                                })}
                            </View>
                        </Card>
                    </View>

                </View>
            </ScrollView>
        </BasicView>
    )
}

export default StepsStatsScreen