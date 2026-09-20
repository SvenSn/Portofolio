import React, { useEffect } from 'react'
import { TouchableOpacity, View, AccessibilityInfo } from 'react-native'
import { useGoNoGo } from '../../../src/hooks/useNoGo'
import BasicView from '../BasicLayoutComponents/BasicView'
import BasicText from '../BasicLayoutComponents/BasicText'

const COLOR_MAP: Record<string, string> = {
    groen: '#38A169',
    rood: '#E53E3E',
    blauw: '#3182CE',
}

const SHAPE_SYMBOL: Record<string, string> = {
    cirkel: '●',
    kruis: '✕',
    driehoek: '▲',
}

type GoNoGoTrialSchermProps = {
    status: string
    currentStimulus: ReturnType<typeof useGoNoGo>['currentStimulus']
    trialIndex: number
    totalTrials: number
    onRespond: () => void
}

const GoNoGoTrialScherm = ({
    status,
    currentStimulus,
    trialIndex,
    totalTrials,
    onRespond,
}: GoNoGoTrialSchermProps) => {

    const voortgang = ((trialIndex + 1) / totalTrials) * 100

    const stimulusLabel =
        currentStimulus?.type === 'shape'
            ? `Vorm ${currentStimulus.value}`
            : currentStimulus?.type === 'color'
                ? `Kleur ${currentStimulus.value}`
                : currentStimulus?.type === 'letter'
                    ? `Letter ${currentStimulus.value}`
                    : ''

    useEffect(() => {
        if (status === 'showing' && stimulusLabel) {
            AccessibilityInfo.announceForAccessibility(stimulusLabel)
        }
    }, [status, stimulusLabel])

    return (
        <TouchableOpacity
            className="flex-1"
            onPress={onRespond}
            activeOpacity={1}
            accessibilityRole="button"
            accessibilityLabel={
                status === 'showing' && currentStimulus
                    ? `${stimulusLabel}. Tik indien dit een GO stimulus is`
                    : 'Wacht op stimulus'
            }
            accessibilityHint="Dubbel tik om te reageren"
        >
            <BasicView className="flex-1 justify-center items-center px-6">

                <BasicView className="absolute top-14 w-full px-6">

                    <View className="flex-row justify-between mb-2">
                        <BasicText
                            variant="label"
                            accessibilityLabel="Voortgang"
                        >
                            Voortgang
                        </BasicText>

                        <BasicText
                            className="font-bold"
                            accessibilityLabel={`Trial ${trialIndex + 1} van ${totalTrials}`}
                        >
                            {trialIndex + 1} / {totalTrials}
                        </BasicText>
                    </View>

                    <View
                        className="w-full h-2 bg-slate-200 dark:bg-slate-700 rounded-full overflow-hidden"
                        accessibilityRole="progressbar"
                        accessibilityValue={{
                            min: 0,
                            max: 100,
                            now: Math.round(voortgang),
                        }}
                    >
                        <View
                            className="h-full bg-sky-600 dark:bg-sky-400 rounded-full"
                            style={{ width: `${voortgang}%` }}
                        />
                    </View>

                </BasicView>

                {status === 'showing' && currentStimulus && (
                    <View className="items-center gap-4">

                        <BasicText
                            accessibilityLabel={stimulusLabel}
                            style={{
                                fontSize: 180,
                                lineHeight: 200,
                                color:
                                    currentStimulus.type === 'color'
                                        ? COLOR_MAP[currentStimulus.value]
                                        : undefined,
                            }}
                        >
                            {currentStimulus.type === 'shape'
                                ? SHAPE_SYMBOL[currentStimulus.value]
                                : null}
                            {currentStimulus.type === 'color' ? '●' : null}
                            {currentStimulus.type === 'letter'
                                ? currentStimulus.value
                                : null}
                        </BasicText>

                        <BasicText
                            variant="label"
                            accessibilityLabel={stimulusLabel}
                        >
                            {currentStimulus.type === 'shape' && currentStimulus.value}
                            {currentStimulus.type === 'color' && currentStimulus.value}
                            {currentStimulus.type === 'letter' && `Letter ${currentStimulus.value}`}
                        </BasicText>

                    </View>
                )}

                <BasicView className="absolute bottom-14">
                    {status === 'showing' && (
                        <BasicText
                            variant="label"
                            accessibilityLabel="Tik op het scherm als dit een GO stimulus is"
                        >
                            Tik aan indien GO
                        </BasicText>
                    )}
                </BasicView>

            </BasicView>
        </TouchableOpacity>
    )
}

export default GoNoGoTrialScherm