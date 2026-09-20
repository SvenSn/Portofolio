import { TextInput, View, AccessibilityInfo } from 'react-native'
import React, { useRef, useEffect } from 'react'
import * as Yup from 'yup'
import { useFormik } from 'formik'
import { useNavigation } from '@react-navigation/native'
import { AuthStackNavProps } from '../../navigators/types'
import BasicButton from '../../components/BasicLayoutComponents/BasicButton'
import { signInAnonymously, signInWithEmailAndPassword } from 'firebase/auth'
import { auth } from '../../firebase'
import BasicText from '../../components/BasicLayoutComponents/BasicText'
import BasicView from '../../components/BasicLayoutComponents/BasicView'
import CardView from '../../components/BasicLayoutComponents/CardView'
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view'
import { SafeAreaView } from 'react-native-safe-area-context'

const validationSchema = Yup.object().shape({
    email: Yup.string().email('Ongeldig email').required('Email verplicht'),
    password: Yup.string().required('Paswoord verplicht'),
})

const LoginScreen = () => {
    const passwordRef = useRef<TextInput>(null)

    const navigation =
        useNavigation<AuthStackNavProps<"Login">["navigation"]>()

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility("Login scherm")
    }, [])

    const {
        handleBlur,
        handleChange,
        handleSubmit,
        values,
        errors,
        touched,
    } = useFormik({
        initialValues: {
            email: '',
            password: '',
        },
        validationSchema,
        onSubmit: async (values) => {
            try {
                await signInWithEmailAndPassword(
                    auth,
                    values.email,
                    values.password
                )

                AccessibilityInfo.announceForAccessibility("Succesvol ingelogd")

            } catch (error: any) {

                let message = "Er is iets misgelopen"

                switch (error.code) {
                    case 'auth/invalid-email':
                        message = 'Email is ongeldig'
                        break
                    case 'auth/user-not-found':
                        message = 'Geen account gevonden met deze email'
                        break
                    case 'auth/wrong-password':
                        message = 'Paswoord is fout'
                        break
                    case 'auth/invalid-credential':
                        message = 'Email of paswoord klopt niet'
                        break
                    case 'auth/too-many-requests':
                        message = 'Te veel pogingen, probeer later opnieuw'
                        break
                }

                alert(message)
                AccessibilityInfo.announceForAccessibility(message)
            }
        },
    })

    return (
        <SafeAreaView style={{ flex: 1 }}>
            <KeyboardAwareScrollView
                contentContainerStyle={{ flexGrow: 1 }}
                enableOnAndroid
                keyboardShouldPersistTaps="handled"
            >
                <BasicView className="flex-1 px-6 justify-center">
                    <BasicView className="mb-8">

                        <BasicText
                            variant="title"
                            className="text-center"
                            accessibilityRole="header"
                        >
                            Welkom terug
                        </BasicText>

                        <BasicText
                            variant="label"
                            className="text-center mt-1"
                            accessibilityLabel="Log in om verder te gaan"
                        >
                            Log in om verder te gaan
                        </BasicText>

                    </BasicView>
                    <CardView className="p-5 gap-5">
                        <View>
                            <BasicText accessibilityLabel="Email">
                                Email
                            </BasicText>

                            <TextInput
                                className={`
                                    px-4 py-3 rounded-2xl border
                                    bg-slate-100 dark:bg-slate-700
                                    text-slate-900 dark:text-slate-50
                                    ${touched.email && errors.email
                                        ? "border-red-500"
                                        : "border-slate-300 dark:border-slate-600"
                                    }
                                `}
                                placeholder="Email"
                                placeholderTextColor="#94a3b8"
                                autoCorrect={false}
                                autoCapitalize="none"
                                keyboardType="email-address"
                                returnKeyType="next"
                                value={values.email}
                                onBlur={handleBlur("email")}
                                onChangeText={handleChange("email")}
                                onSubmitEditing={() => passwordRef.current?.focus()}
                                accessibilityLabel="Voer je email in"
                                accessibilityHint="Gebruik je geregistreerde email"
                            />

                            {touched.email && errors.email && (
                                <BasicText
                                    className="text-red-500 text-sm mt-1"
                                    accessibilityLabel={errors.email}
                                >
                                    {errors.email}
                                </BasicText>
                            )}
                        </View>
                        <View>
                            <BasicText accessibilityLabel="Paswoord">
                                Paswoord
                            </BasicText>

                            <TextInput
                                ref={passwordRef}
                                className={`
                                    px-4 py-3 rounded-2xl border
                                    bg-slate-100 dark:bg-slate-700
                                    text-slate-900 dark:text-slate-50
                                    ${touched.password && errors.password
                                        ? "border-red-500"
                                        : "border-slate-300 dark:border-slate-600"
                                    }
                                `}
                                placeholder="Paswoord"
                                placeholderTextColor="#94a3b8"
                                secureTextEntry
                                autoCorrect={false}
                                autoCapitalize="none"
                                returnKeyType="done"
                                value={values.password}
                                onBlur={handleBlur("password")}
                                onChangeText={handleChange("password")}
                                onSubmitEditing={() => handleSubmit()}
                                accessibilityLabel="Voer je paswoord in"
                                accessibilityHint="Gebruik je persoonlijke paswoord"
                            />

                            {touched.password && errors.password && (
                                <BasicText
                                    className="text-red-500 text-sm mt-1"
                                    accessibilityLabel={errors.password}
                                >
                                    {errors.password}
                                </BasicText>
                            )}
                        </View>

                    </CardView>
                    <View className="mt-6 gap-3">

                        <BasicButton
                            title="Login"
                            onPress={handleSubmit}
                            accessibilityRole="button"
                            accessibilityLabel="Login"
                            accessibilityHint="Log in met email en paswoord"
                        />

                        <BasicButton
                            title="Login als gast"
                            onPress={() => {
                                signInAnonymously(auth)
                                AccessibilityInfo.announceForAccessibility("Ingelogd als gast")
                            }}
                            accessibilityRole="button"
                            accessibilityLabel="Login als gast"
                        />

                        <BasicButton
                            title="Nog geen account?"
                            onPress={() => {
                                navigation.replace("Register")
                                AccessibilityInfo.announceForAccessibility("Ga naar registratie scherm")
                            }}
                            accessibilityRole="button"
                            accessibilityLabel="Ga naar registratie"
                        />

                    </View>

                </BasicView>
            </KeyboardAwareScrollView>
        </SafeAreaView>
    )
}

export default LoginScreen