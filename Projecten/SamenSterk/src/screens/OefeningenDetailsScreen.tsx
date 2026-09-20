import React, { useEffect } from 'react'
import { ScrollView, View, AccessibilityInfo } from 'react-native'
import { useNavigation, useRoute } from '@react-navigation/native'
import { OefeningenStackNavProps } from '../navigators/types'
import { auth } from '../firebase'
import BasicButton from '../components/BasicLayoutComponents/BasicButton'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import CardView from '../components/BasicLayoutComponents/CardView'

const OefeningenDetailsScreen = () => {
    const {
        params: { data },
    } = useRoute<OefeningenStackNavProps<"OefeningDetails">["route"]>()

    const user = auth.currentUser
    const isAnonymous = user?.isAnonymous
    const navigation = useNavigation()

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility(
            `${data.name ?? "Oefening"}. ${data.KorteBeschrijving ?? ""}`
        )
    }, [])

    return (
        <ScrollView
            className="flex-1"
            showsVerticalScrollIndicator={false}
            contentContainerClassName="pb-10"
        >

            <BasicView
                className="px-4 items-center pt-10 pb-6 bg-sky-600"
                accessibilityRole="header"
            >

                <BasicText
                    className="text-3xl font-bold text-white"
                    accessibilityLabel={data.name ?? "Oefening"}
                >
                    {data.name ?? "Onbekend"}
                </BasicText>

                <BasicText
                    className="mt-3 text-sky-100 leading-6"
                    accessibilityLabel={data.KorteBeschrijving ?? ""}
                >
                    {data.KorteBeschrijving ?? ""}
                </BasicText>

            </BasicView>

            <BasicView className="p-4 gap-6">

                <CardView
                    className="p-5 border border-slate-200 dark:border-slate-700"
                    accessible={true}
                    accessibilityLabel={`Beschrijving. ${data.LangeBeschrijving ?? ""}`}
                >
                    <BasicText variant="label">
                        Beschrijving
                    </BasicText>

                    <BasicText accessibilityLabel={data.LangeBeschrijving ?? ""}>
                        {data.LangeBeschrijving ?? ""}
                    </BasicText>
                </CardView>

                <BasicText
                    variant="title"
                    accessibilityRole="header"
                    accessibilityLabel="Stappen"
                >
                    Stappen
                </BasicText>

                {data.steps.map(step => (
                    <CardView
                        key={step.order}
                        className="p-5 flex-row items-start gap-4 border border-slate-200 dark:border-slate-700"
                        accessible={true}
                        accessibilityLabel={`Stap ${step.order}. ${step.beschrijving ?? ""}`}
                    >

                        <View
                            className="w-10 h-10 rounded-full bg-sky-600 items-center justify-center"
                            accessibilityLabel={`Stap ${step.order}`}
                        >
                            <BasicText className="text-white font-bold">
                                {step.order}
                            </BasicText>
                        </View>

                        <BasicText
                            className="flex-1"
                            accessibilityLabel={step.beschrijving ?? ""}
                        >
                            {step.beschrijving ?? ""}
                        </BasicText>

                    </CardView>
                ))}

                {!isAnonymous && (
                    <BasicButton
                        title="Inplannen oefening"
                        onPress={() => {
                            AccessibilityInfo.announceForAccessibility("Ga naar oefening inplannen")
                            navigation.navigate('OefeningenInplannen', { data })
                        }}
                        accessibilityRole="button"
                        accessibilityLabel="Oefening inplannen"
                        accessibilityHint="Plan deze oefening in je kalender"
                    />
                )}

            </BasicView>

        </ScrollView>
    )
}

export default OefeningenDetailsScreen;