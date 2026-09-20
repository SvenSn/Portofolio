import React, { useEffect } from 'react'
import { ScrollView, View, AccessibilityInfo } from 'react-native'
import { useGoNoGo } from '../../../src/hooks/useNoGo'
import SectieContainer from '../../components/SectieContainer'
import InfoRij from '../../components/InfoRij'
import BasicButton from '../BasicLayoutComponents/BasicButton'
import BasicView from '../BasicLayoutComponents/BasicView'
import BasicText from '../BasicLayoutComponents/BasicText'

type GoNoGoResultaatProps = {
    score: NonNullable<ReturnType<typeof useGoNoGo>['score']>
    onOpnieuw: () => void
}

const GoNoGoResultaat = ({ score, onOpnieuw }: GoNoGoResultaatProps) => {

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility(
            `Resultaat. Je score is ${score.score} op 100. 
            ${score.correctGo} correcte reacties. 
            ${score.correctInhibit} correcte remmingen. 
            ${score.falseAlarms} foutieve reacties. 
            ${score.misses} gemiste reacties.`
        )
    }, [])

    return (
        <ScrollView
            className="flex-1"
            showsVerticalScrollIndicator={false}
            contentContainerClassName="px-6 pt-12 pb-10 gap-6"
        >

            <BasicView accessibilityRole="header">
                <BasicText
                    variant="label"
                    accessibilityLabel="Go No Go test"
                >
                    Go / No-Go
                </BasicText>

                <BasicText
                    variant="title"
                    accessibilityLabel="Resultaat"
                >
                    Resultaat
                </BasicText>
            </BasicView>

            <SectieContainer
                className="items-center py-10"
                accessible={true}
                accessibilityLabel={`Totaalscore ${score.score} op 100`}
            >

                <BasicText
                    variant="label"
                    accessibilityLabel="Totaalscore"
                >
                    Totaalscore
                </BasicText>

                <BasicText
                    className="font-bold text-center text-sky-600 dark:text-sky-400"
                    style={{ fontSize: 100, lineHeight: 110 }}
                    accessibilityLabel={`${score.score} op 100`}
                >
                    {score.score}
                </BasicText>

                <BasicText
                    variant="label"
                    accessibilityLabel="van 100"
                >
                    van 100
                </BasicText>

            </SectieContainer>

            <SectieContainer
                className="gap-1"
                accessibilityLabel="Details van je resultaat"
            >

                <BasicText
                    variant="label"
                    accessibilityLabel="Details"
                >
                    Details
                </BasicText>

                <InfoRij
                    emoji="✅"
                    titel="Correct gereageerd"
                    value={score.correctGo}
                    accessibilityLabel={`${score.correctGo} keer correct gereageerd`}
                />
                <InfoRij
                    emoji="🛑"
                    titel="Correct geïnhibeerd"
                    value={score.correctInhibit}
                    accessibilityLabel={`${score.correctInhibit} keer correct geremd`}
                />
                <InfoRij
                    emoji="⚠️"
                    titel="False alarms"
                    value={score.falseAlarms}
                    accessibilityLabel={`${score.falseAlarms} foutieve reacties`}
                />
                <InfoRij
                    emoji="❌"
                    titel="Gemiste reacties"
                    value={score.misses}
                    accessibilityLabel={`${score.misses} gemiste reacties`}
                />

                {score.avgReactionTime && (
                    <InfoRij
                        emoji="⏱️"
                        titel="Gem. reactietijd"
                        value={`${score.avgReactionTime} ms`}
                        accessibilityLabel={`Gemiddelde reactietijd ${score.avgReactionTime} milliseconden`}
                    />
                )}

            </SectieContainer>

            <View className="pt-2">
                <BasicButton
                    title="Opnieuw spelen"
                    onPress={onOpnieuw}
                    accessibilityRole="button"
                    accessibilityLabel="Opnieuw spelen"
                    accessibilityHint="Start de oefening opnieuw"
                />
            </View>

        </ScrollView>
    )
}

export default GoNoGoResultaat