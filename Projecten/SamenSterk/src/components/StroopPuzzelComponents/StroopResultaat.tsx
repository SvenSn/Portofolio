import React, { useEffect } from 'react'
import { ScrollView, AccessibilityInfo } from 'react-native'
import { useStroop } from '../../../src/hooks/useStroop'
import SectieContainer from "../SectieContainer"
import InfoRij from '../InfoRij'
import BasicButton from '../BasicLayoutComponents/BasicButton'
import BasicView from '../BasicLayoutComponents/BasicView'
import BasicText from '../BasicLayoutComponents/BasicText'

type StroopResultaatProps = {
    score: NonNullable<ReturnType<typeof useStroop>['score']>
    onRetry: () => void
}

const StroopResultaat = ({ score, onRetry }: StroopResultaatProps) => {

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility(
            `Resultaat. Je score is ${score.score} op 100. 
            ${score.correct} correcte antwoorden. 
            ${score.wrong} foute antwoorden. 
            ${score.timeout} keer te laat.`
        )
    }, [])

    return (
        <ScrollView
            className="flex-1"
            showsVerticalScrollIndicator={false}
            contentContainerClassName="px-6 pt-12 pb-8 gap-6"
        >

            <BasicView accessibilityRole="header">
                <BasicText
                    variant="label"
                    accessibilityLabel="Stroop taak"
                >
                    Stroop Taak
                </BasicText>

                <BasicText
                    variant="title"
                    accessibilityLabel="Resultaat"
                >
                    Resultaat
                </BasicText>
            </BasicView>

            <SectieContainer
                className="items-center py-8 gap-2"
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
                    className="text-8xl leading-[96px] font-bold text-center"
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
                className="gap-2"
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
                    titel="Correct"
                    value={score.correct}
                    accessibilityLabel={`${score.correct} correcte antwoorden`}
                />

                <InfoRij
                    emoji="❌"
                    titel="Fout"
                    value={score.wrong}
                    accessibilityLabel={`${score.wrong} foute antwoorden`}
                />

                <InfoRij
                    emoji="⏱️"
                    titel="Tijd op"
                    value={score.timeout}
                    accessibilityLabel={`${score.timeout} keer te laat`}
                />

                {score.avgReactionTime && (
                    <InfoRij
                        emoji="⚡"
                        titel="Gem. reactietijd"
                        value={`${score.avgReactionTime} ms`}
                        accessibilityLabel={`Gemiddelde reactietijd ${score.avgReactionTime} milliseconden`}
                    />
                )}

            </SectieContainer>

            <BasicButton
                title="Opnieuw spelen"
                onPress={onRetry}
                accessibilityRole="button"
                accessibilityLabel="Opnieuw spelen"
                accessibilityHint="Start de oefening opnieuw"
            />

        </ScrollView>
    )
}

export default StroopResultaat