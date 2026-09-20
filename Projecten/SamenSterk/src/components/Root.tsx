import React, { useEffect, useRef, useState } from 'react'
import { SafeAreaProvider } from "react-native-safe-area-context"
import { NavigationContainer } from '@react-navigation/native'
import SamenSterkTabNavigator from '../navigators/SamenSterkTabNavigator'
import { useAppDispatch, useAppSelector } from './../hooks/ReduxHooks'
import '../../global.css'
import { RootState } from '../store/store'
import AuthStackNavigator from '../navigators/AuthStackNavigator'
import { colorScheme } from "nativewind"
import { auth, db } from '../firebase'
import { onAuthStateChanged } from 'firebase/auth'
import { onSnapshot, doc } from 'firebase/firestore'
import * as SplashScreen from "expo-splash-screen"
import 'react-native-gesture-handler'
import { loadSettings, saveSettings } from '../store/accountsettings/settingsStorage'
import { setSettings } from '../store/accountsettings/settingsSlice'
import { MyDarkTheme, MyLightTheme } from '../theme/themas'
import { setGebruiker, clearGebruiker } from '../store/gebruiker/gebruikerSlice'

SplashScreen.preventAutoHideAsync()

const Root = () => {

    const [isLoggedIn, setIsLoggedIn] = useState(false)
    const [isAuthLoading, setIsAuthLoading] = useState(true)
    const [isSettingsLoading, setIsSettingsLoading] = useState(true)
    const [uid, setUid] = useState<string | null>(null)

    const navigationRef = useRef(null)

    const dispatch = useAppDispatch()
    const settings = useAppSelector((state: RootState) => state.accountSettings)

    useEffect(() => {
        colorScheme.set(settings.darkMode ? "dark" : "light")
    }, [settings.darkMode])

    useEffect(() => {
        const init = async () => {
            const stored = await loadSettings()
            if (stored) {
                dispatch(setSettings(stored))
            }
            setIsSettingsLoading(false)
        }
        init()
    }, [])

    useEffect(() => {
        const unsubscribe = onAuthStateChanged(auth, (user) => {

            setIsLoggedIn(!!user)
            setIsAuthLoading(false)

            if (user) {
                setUid(user.uid)
            } else {
                setUid(null)
                dispatch(clearGebruiker())
            }
        })

        return unsubscribe
    }, [])

    useEffect(() => {
        if (!uid) return

        const unsubscribe = onSnapshot(
            doc(db, "gebruikers", uid),
            (docSnap) => {

                if (docSnap.exists()) {
                    dispatch(setGebruiker({
                        isAdmin: docSnap.data().isAdmin ?? false
                    }))
                } else {
                    dispatch(setGebruiker({ isAdmin: false }))
                }
            }
        )

        return unsubscribe
    }, [uid])

    useEffect(() => {
        if (!isSettingsLoading) {
            saveSettings(settings)
        }
    }, [settings, isSettingsLoading])

    useEffect(() => {
        if (!isAuthLoading && !isSettingsLoading) {
            SplashScreen.hideAsync()
        }
    }, [isAuthLoading, isSettingsLoading])

    if (isAuthLoading || isSettingsLoading) {
        return null
    }

    return (
        <SafeAreaProvider>
            <NavigationContainer
                ref={navigationRef}
                theme={settings.darkMode ? MyDarkTheme : MyLightTheme}
            >
                {isLoggedIn
                    ? <SamenSterkTabNavigator />
                    : <AuthStackNavigator />}
            </NavigationContainer>
        </SafeAreaProvider>
    )
}

export default Root
