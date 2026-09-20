import { Switch, View, AccessibilityInfo } from 'react-native'
import React, { useEffect } from 'react'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import CardView from '../components/BasicLayoutComponents/CardView'
import { useSettings } from './../hooks/useSettings'

const ToegangkelijkheidScreen = () => {
    const { darkMode, textSize, setDarkMode, setTextSize } = useSettings()

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility("Toegankelijkheids instellingen")
    }, [])

    return (
        <BasicView className="flex-1 p-6 gap-6">

            <BasicText
                variant="title"
                accessibilityRole="header"
            >
                Toegankelijkheid
            </BasicText>

            <CardView className="divide-y divide-slate-200 dark:divide-slate-700">

                <View
                    className="py-4 flex-row items-center justify-between"
                    accessibilityLabel={`Donkere modus ${darkMode ? "aan" : "uit"}`}
                >
                    <View className="flex-1 pr-4">

                        <BasicText accessibilityLabel="Donkere modus">
                            Donkere modus
                        </BasicText>

                        <BasicText
                            variant="label"
                            accessibilityLabel="Vermindert fel licht en is rustiger voor de ogen"
                        >
                            Vermindert fel licht en is rustiger voor de ogen
                        </BasicText>

                    </View>

                    <Switch
                        value={darkMode}
                        onValueChange={(val) => {
                            setDarkMode(val)

                            AccessibilityInfo.announceForAccessibility(
                                val ? "Donkere modus ingeschakeld" : "Donkere modus uitgeschakeld"
                            )
                        }}
                        accessibilityRole="switch"
                        accessibilityLabel="Schakel donkere modus"
                        accessibilityState={{ checked: darkMode }}
                    />

                </View>
                <View
                    className="py-4 flex-row items-center justify-between"
                    accessibilityLabel={`Grotere tekst ${textSize === 'large' ? "aan" : "uit"}`}
                >
                    <View className="flex-1 pr-4">

                        <BasicText accessibilityLabel="Grotere tekst">
                            Grotere tekst
                        </BasicText>

                        <BasicText
                            variant="label"
                            accessibilityLabel="Vergroot teksten voor betere leesbaarheid"
                        >
                            Vergroot teksten voor betere leesbaarheid
                        </BasicText>

                    </View>

                    <Switch
                        value={textSize === 'large'}
                        onValueChange={(val) => {
                            const newValue = val ? 'large' : 'normal'
                            setTextSize(newValue)

                            AccessibilityInfo.announceForAccessibility(
                                val ? "Grotere tekst ingeschakeld" : "Grotere tekst uitgeschakeld"
                            )
                        }}
                        accessibilityRole="switch"
                        accessibilityLabel="Schakel grotere tekst"
                        accessibilityState={{ checked: textSize === 'large' }}
                    />

                </View>

            </CardView>
            <CardView
                className="gap-2 p-5"
                accessible={true}
                accessibilityLabel="Voorbeeld tekst om instellingen te testen"
            >

                <BasicText accessibilityLabel="Voorbeeld">
                    Voorbeeld
                </BasicText>

                <BasicText
                    accessibilityLabel="Dit is een voorbeeldtekst om de grootte en dark mode te testen"
                >
                    Dit is een voorbeeldtekst om de grootte en dark mode te testen.
                </BasicText>

            </CardView>

        </BasicView>
    )
}

export default ToegangkelijkheidScreen
