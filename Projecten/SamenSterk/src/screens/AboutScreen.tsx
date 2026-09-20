import React, { useEffect } from 'react'
import { ScrollView, AccessibilityInfo } from 'react-native'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import BasicText from '../components/BasicLayoutComponents/BasicText'

const AboutScreen = () => {

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility(
            "Over SamenSterk. SamenSterk helpt mensen groeien met oefeningen en puzzels aangepast aan hun mogelijkheden."
        )
    }, [])

    return (
        <ScrollView
            className="flex-1"
            showsVerticalScrollIndicator={false}
            contentContainerClassName="px-6 py-8 gap-5"
        >

            <BasicView accessibilityRole="header">

                <BasicText
                    variant="title"
                    className="text-3xl"
                    accessibilityLabel="Over SamenSterk"
                >
                    Over SamenSterk
                </BasicText>

                <BasicText
                    className="text-lg leading-7 mt-4"
                    accessibilityLabel="Bij SamenSterk geloven we dat iedereen recht heeft op groei, oefening en succeservaringen."
                >
                    Bij SamenSterk geloven we dat iedereen recht heeft op groei, oefening en succeservaringen.
                </BasicText>

                <BasicText
                    className="text-lg leading-7 mt-3"
                    accessibilityLabel="Daarom bieden we een gebruiksvriendelijke app met aangepaste puzzels en oefeningen die inspelen op verschillende noden en mogelijkheden."
                >
                    Daarom bieden we een gebruiksvriendelijke app met aangepaste puzzels en oefeningen die inspelen op verschillende noden en mogelijkheden.
                </BasicText>

                <BasicText
                    className="text-lg leading-7 mt-3"
                    accessibilityLabel="Of je nu werkt aan concentratie, reactiesnelheid of cognitieve vaardigheden, SamenSterk helpt je stap voor stap vooruit, op jouw tempo."
                >
                    Of je nu werkt aan concentratie, reactiesnelheid of cognitieve vaardigheden — SamenSterk helpt je stap voor stap vooruit, op jouw tempo.
                </BasicText>

                <BasicText
                    className="text-lg leading-7 font-semibold mt-3"
                    accessibilityLabel="Samen maken we ontwikkeling toegankelijk, eenvoudig en motiverend."
                >
                    Samen maken we ontwikkeling toegankelijk, eenvoudig en motiverend.
                </BasicText>

            </BasicView>

        </ScrollView>
    )
}

export default AboutScreen
