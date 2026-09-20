import React, { useEffect } from 'react'
import { ScrollView, TouchableOpacity, View, AccessibilityInfo } from 'react-native'
import BasicView from '../../../src/components/BasicLayoutComponents/BasicView'
import BasicText from '../../../src/components/BasicLayoutComponents/BasicText'
import CardView from '../../../src/components/BasicLayoutComponents/CardView'
import { useStroop } from '../../../src/hooks/useStroop'
import { StroopColor } from '../../../src/puzzels/StroopPuzzel/StroopTypes'

const COLOR_MAP: Record<StroopColor, string> = {
    red: '#E53E3E',
    blue: '#3182CE',
    green: '#38A169',
    yellow: '#D69E2E',
}

const COLOR_LABELS: Record<StroopColor, string> = {
    red: 'Rood',
    blue: 'Blauw',
    green: 'Groen',
    yellow: 'Geel',
}

type StroopTrialProps = {
    currentStimulus: ReturnType<typeof useStroop>['currentStimulus']
    trialIndex: number
    totalTrials: number
    onAnswer: (color: StroopColor) => void
}

const AntwoordKnop = ({
    color,
    onPress
}: {
    color: StroopColor
    onPress: () => void
}) => (
    <TouchableOpacity
        activeOpacity={0.8}
        onPress={onPress}
        className="flex-1"
        accessibilityRole="button"
        accessibilityLabel={COLOR_LABELS[color]}
        accessibilityHint={`Dubbel tik om ${COLOR_LABELS[color]} te kiezen`}
    >
        <CardView className="py-5 items-center justify-center gap-2 border border-slate-200 dark:border-slate-700">

            <View
                className="w-5 h-5 rounded-full"
                style={{ backgroundColor: COLOR_MAP[color] }}
                accessible={false}
            />

            <BasicText accessibilityLabel={COLOR_LABELS[color]}>
                {COLOR_LABELS[color]}
            </BasicText>

        </CardView>
    </TouchableOpacity>
)

const StroopTrialScherm = ({
    currentStimulus,
    trialIndex,
    totalTrials,
    onAnswer,
}: StroopTrialProps) => {

    const progress = ((trialIndex + 1) / totalTrials) * 100

    const stimulusLabel = currentStimulus
        ? `Het woord ${COLOR_LABELS[currentStimulus.word]} staat in de kleur ${COLOR_LABELS[currentStimulus.color]}. Welke kleur heeft de tekst?`
        : ''

    useEffect(() => {
        if (currentStimulus) {
            AccessibilityInfo.announceForAccessibility(stimulusLabel)
        }
    }, [stimulusLabel, currentStimulus])

    return (
        <BasicView className="flex-1 px-6 pt-10 pb-8 justify-between">

            <BasicView className="gap-2">

                <BasicView className="flex-row justify-between items-center">
                    <BasicText
                        variant="label"
                        accessibilityLabel="Voortgang"
                    >
                        Voortgang
                    </BasicText>

                    <BasicText
                        className="font-medium"
                        accessibilityLabel={`Trial ${trialIndex + 1} van ${totalTrials}`}
                    >
                        {trialIndex + 1} / {totalTrials}
                    </BasicText>
                </BasicView>

                <View
                    className="w-full h-2 bg-slate-200 dark:bg-slate-700 rounded-full overflow-hidden"
                    accessibilityRole="progressbar"
                    accessibilityValue={{
                        min: 0,
                        max: 100,
                        now: Math.round(progress),
                    }}
                    accessibilityLabel={`Voortgang ${Math.round(progress)} procent`}
                >
                    <View
                        className="h-2 bg-sky-600"
                        style={{ width: `${progress}%` }}
                    />
                </View>

            </BasicView>

            <BasicView className="items-center gap-4">

                {currentStimulus && (
                    <>
                        <BasicText
                            className="text-6xl font-bold text-center max-w-[260px] break-words"
                            adjustsFontSizeToFit
                            numberOfLines={2}
                            style={{ color: COLOR_MAP[currentStimulus.color] }}
                            accessibilityLabel={`Woord ${COLOR_LABELS[currentStimulus.word]} in ${COLOR_LABELS[currentStimulus.color]}e kleur`}
                        >
                            {COLOR_LABELS[currentStimulus.word]}
                        </BasicText>

                        <BasicText
                            variant="label"
                            className="text-center"
                            accessibilityLabel="Welke kleur heeft de tekst?"
                        >
                            Welke kleur heeft de tekst?
                        </BasicText>
                    </>
                )}

            </BasicView>

            <BasicView
                className="gap-3"
                accessibilityLabel="Antwoordopties"
            >
                <BasicView className="flex-row gap-3">
                    <AntwoordKnop color="red" onPress={() => onAnswer('red')} />
                    <AntwoordKnop color="blue" onPress={() => onAnswer('blue')} />
                </BasicView>

                <BasicView className="flex-row gap-3">
                    <AntwoordKnop color="green" onPress={() => onAnswer('green')} />
                    <AntwoordKnop color="yellow" onPress={() => onAnswer('yellow')} />
                </BasicView>
            </BasicView>

        </BasicView>
    )
}

export default StroopTrialScherm