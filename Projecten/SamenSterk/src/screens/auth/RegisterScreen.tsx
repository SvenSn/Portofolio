import { TextInput, View, TouchableWithoutFeedback, Keyboard, AccessibilityInfo } from 'react-native'
import React, { useRef, useEffect } from 'react'
import BasicText from '../../components/BasicLayoutComponents/BasicText'
import BasicButton from '../../components/BasicLayoutComponents/BasicButton'
import BasicView from '../../components/BasicLayoutComponents/BasicView'
import CardView from '../../components/BasicLayoutComponents/CardView'
import * as Yup from 'yup'
import { useFormik } from 'formik'
import { createUserWithEmailAndPassword, updateProfile } from 'firebase/auth'
import { auth } from '../../firebase'
import { useNavigation } from '@react-navigation/native'
import { AuthStackNavProps } from '../../navigators/types'
import { SafeAreaView } from 'react-native-safe-area-context'
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view'

const validationSchema = Yup.object().shape({
    gebruikersnaam: Yup.string().required('Gebruikersnaam is verplicht'),
    email: Yup.string().email('Ongeldig emailadres').required('Email verplicht'),
    password: Yup.string()
        .required('Paswoord verplicht')
        .min(8, 'Min 8 karakters')
        .matches(/[A-Z]/, 'Minstens één hoofdletter')
        .matches(/[0-9]/, 'Minstens één cijfer')
        .matches(/[^A-Za-z0-9]/, 'Minstens één symbool'),
    passwordConfirm: Yup.string()
        .oneOf([Yup.ref('password')], 'Wachtwoorden komen niet overeen')
        .required('Verplicht'),
})

const RegisterScreen = () => {
    const emailRef = useRef<TextInput>(null)
    const passwordRef = useRef<TextInput>(null)
    const confirmRef = useRef<TextInput>(null)

    const navigation =
        useNavigation<AuthStackNavProps<'Register'>['navigation']>()

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility("Account registreren scherm")
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
            gebruikersnaam: '',
            email: '',
            password: '',
            passwordConfirm: '',
        },
        validationSchema,
        onSubmit: async (values) => {
            try {
                const userCred = await createUserWithEmailAndPassword(
                    auth,
                    values.email,
                    values.password
                )

                await updateProfile(userCred.user, {
                    displayName: values.gebruikersnaam,
                })

                AccessibilityInfo.announceForAccessibility("Account succesvol aangemaakt")

            } catch (error: any) {
                AccessibilityInfo.announceForAccessibility("Fout bij registreren")
            }
        },
    })

    const inputStyle = (hasError: boolean) => `
        px-4 py-3 rounded-2xl border
        bg-slate-100 dark:bg-slate-700
        text-slate-900 dark:text-slate-50
        ${hasError
            ? 'border-red-500'
            : 'border-slate-300 dark:border-slate-600'
        }
    `

    return (
        <SafeAreaView className="flex-1">
            <KeyboardAwareScrollView
                contentContainerStyle={{ flexGrow: 1 }}
                enableOnAndroid
                extraScrollHeight={20}
                keyboardShouldPersistTaps="handled"
            >
                <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
                    <BasicView className="flex-1 px-6 py-6">

                        <BasicView className="mb-8">

                            <BasicText
                                variant="title"
                                className="text-center"
                                accessibilityRole="header"
                            >
                                Account aanmaken
                            </BasicText>

                            <BasicText
                                className="text-center mt-1"
                                accessibilityLabel="Vul je gegevens in"
                            >
                                Vul je gegevens in
                            </BasicText>

                        </BasicView>

                        <CardView className="p-5 gap-5">

                            <View>
                                <BasicText accessibilityLabel="Gebruikersnaam">
                                    Gebruikersnaam
                                </BasicText>

                                <TextInput
                                    className={inputStyle(!!(errors.gebruikersnaam && touched.gebruikersnaam))}
                                    value={values.gebruikersnaam}
                                    onBlur={handleBlur('gebruikersnaam')}
                                    onChangeText={handleChange('gebruikersnaam')}
                                    returnKeyType="next"
                                    onSubmitEditing={() => emailRef.current?.focus()}
                                    accessibilityLabel="Voer gebruikersnaam in"
                                />

                                {touched.gebruikersnaam && errors.gebruikersnaam && (
                                    <BasicText accessibilityLabel={errors.gebruikersnaam}>
                                        {errors.gebruikersnaam}
                                    </BasicText>
                                )}
                            </View>

                            <View>
                                <BasicText accessibilityLabel="Email">
                                    Email
                                </BasicText>

                                <TextInput
                                    ref={emailRef}
                                    className={inputStyle(!!(errors.email && touched.email))}
                                    keyboardType="email-address"
                                    autoCapitalize="none"
                                    value={values.email}
                                    onBlur={handleBlur('email')}
                                    onChangeText={handleChange('email')}
                                    returnKeyType="next"
                                    onSubmitEditing={() => passwordRef.current?.focus()}
                                    accessibilityLabel="Voer email in"
                                />

                                {touched.email && errors.email && (
                                    <BasicText accessibilityLabel={errors.email}>
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
                                    className={inputStyle(!!(errors.password && touched.password))}
                                    secureTextEntry
                                    value={values.password}
                                    onBlur={handleBlur('password')}
                                    onChangeText={handleChange('password')}
                                    returnKeyType="next"
                                    onSubmitEditing={() => confirmRef.current?.focus()}
                                    accessibilityLabel="Voer paswoord in"
                                />

                                {touched.password && errors.password && (
                                    <BasicText accessibilityLabel={errors.password}>
                                        {errors.password}
                                    </BasicText>
                                )}
                            </View>

                            <View>
                                <BasicText accessibilityLabel="Bevestig paswoord">
                                    Bevestig paswoord
                                </BasicText>

                                <TextInput
                                    ref={confirmRef}
                                    className={inputStyle(!!(errors.passwordConfirm && touched.passwordConfirm))}
                                    secureTextEntry
                                    value={values.passwordConfirm}
                                    onBlur={handleBlur('passwordConfirm')}
                                    onChangeText={handleChange('passwordConfirm')}
                                    returnKeyType="done"
                                    onSubmitEditing={() => handleSubmit()}
                                    accessibilityLabel="Herhaal paswoord"
                                />

                                {touched.passwordConfirm && errors.passwordConfirm && (
                                    <BasicText accessibilityLabel={errors.passwordConfirm}>
                                        {errors.passwordConfirm}
                                    </BasicText>
                                )}
                            </View>

                        </CardView>

                        <View className="mt-6 gap-3">

                            <BasicButton
                                title="Account aanmaken"
                                onPress={handleSubmit}
                                accessibilityRole="button"
                                accessibilityLabel="Account aanmaken"
                            />

                            <BasicButton
                                title="Al een account?"
                                onPress={() => {
                                    navigation.replace('Login')
                                    AccessibilityInfo.announceForAccessibility("Ga naar login")
                                }}
                                accessibilityRole="button"
                                accessibilityLabel="Ga naar login"
                            />

                        </View>

                    </BasicView>
                </TouchableWithoutFeedback>
            </KeyboardAwareScrollView>
        </SafeAreaView>
    )
}

export default RegisterScreen