import React, { useEffect } from 'react'
import { View, TouchableOpacity, Text, Switch, AccessibilityInfo } from 'react-native'
import { signOut } from 'firebase/auth';
import { auth } from '../firebase'

const InstellingenScreen = () => {

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility("Instellingen scherm")
    }, [])

    return (
        <View className="flex-1 px-6 py-6 gap-6">

            <View>
                <Text
                    accessibilityRole="header"
                    accessibilityLabel="Instellingen"
                >
                    Instellingen
                </Text>
            </View>

            <View
                className="flex-row items-center justify-between"
                accessibilityLabel="Donkere modus instelling"
            >
                <Text
                    accessibilityLabel="Donkere modus"
                >
                    Dark Mode
                </Text>

                <Switch
                    accessibilityLabel="Schakel donkere modus in of uit"
                    accessibilityRole="switch"
                />
            </View>

            <TouchableOpacity
                className='bg-sky-400 rounded-lg py-4'
                onPress={() => {
                    signOut(auth)
                    AccessibilityInfo.announceForAccessibility("Uitgelogd")
                }}
                accessibilityRole="button"
                accessibilityLabel="Uitloggen"
                accessibilityHint="Log uit van je account"
            >
                <Text
                    className='text-center text-3xl'
                    accessibilityLabel="Uitloggen"
                >
                    Log uit
                </Text>
            </TouchableOpacity>

        </View>
    )
}

export default InstellingenScreen