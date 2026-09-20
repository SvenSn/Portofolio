import React, { useRef, useEffect } from 'react'
import {
    TextInput,
    View,
    Alert,
    TouchableWithoutFeedback,
    Keyboard,
    AccessibilityInfo,
} from 'react-native'
import * as Yup from 'yup'
import { useFormik } from 'formik'
import BasicView from '../../components/BasicLayoutComponents/BasicView'
import BasicText from '../../components/BasicLayoutComponents/BasicText'
import CardView from '../../components/BasicLayoutComponents/CardView'
import BasicButton from '../../components/BasicLayoutComponents/BasicButton'
import {
    EmailAuthProvider,
    reauthenticateWithCredential,
    updatePassword,
} from 'firebase/auth'
import { auth } from '../../firebase'
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view'

const validationSchema = Yup.object().shape({
    currentPassword: Yup.string().required('Huidig paswoord verplicht'),
    password: Yup.string()
        .min(6, 'Minstens 6 karakters')
        .required('Nieuw paswoord verplicht'),
    confirm: Yup.string()
        .oneOf([Yup.ref('password')], 'Komt niet overeen')
        .required('Bevestiging verplicht'),
})

const PaswoordChangeScreen = () => {
    const newPasswordRef = useRef<TextInput>(null)
    const confirmRef = useRef<TextInput>(null)

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility("Paswoord wijzigen scherm")
    }, [])

    const {
        values,
        errors,
        touched,
        handleChange,
        handleBlur,
        handleSubmit,
        isSubmitting,
        resetForm,
    } = useFormik({
        initialValues: {
            currentPassword: '',
            password: '',
            confirm: '',
        },
        validationSchema,
        onSubmit: async ({ currentPassword, password }) => {
            const user = auth.currentUser

            if (!user || !user.email) {
                const msg = 'Geen gebruiker of email gevonden'
                Alert.alert('Fout', msg)
                AccessibilityInfo.announceForAccessibility(msg)
                return
            }

            try {
                const credential = EmailAuthProvider.credential(
                    user.email,
                    currentPassword
                )

                await reauthenticateWithCredential(user, credential)
                await updatePassword(user, password)

                resetForm()

                Alert.alert('Succes', 'Je paswoord is gewijzigd')
                AccessibilityInfo.announceForAccessibility("Paswoord succesvol gewijzigd")

            } catch (error: any) {

                let message = 'Kon paswoord niet wijzigen'

                if (error?.code === 'auth/wrong-password' || error?.code === 'auth/invalid-credential') {
                    message = 'Huidig paswoord is niet correct'
                } else if (error?.code === 'auth/weak-password') {
                    message = 'Nieuw paswoord is te zwak'
                } else if (error?.code === 'auth/requires-recent-login') {
                    message = 'Log opnieuw in en probeer opnieuw'
                }

                Alert.alert('Fout', message)
                AccessibilityInfo.announceForAccessibility(message)
            }
        },
    })

    const input = (error?: boolean) => `
        px-4 py-3 rounded-2xl border
        bg-slate-100 dark:bg-slate-700
        text-slate-900 dark:text-slate-50
        ${error ? 'border-red-500' : 'border-slate-300 dark:border-slate-600'}
    `

    return (
        <KeyboardAwareScrollView
            contentContainerStyle={{ flexGrow: 1 }}
            enableOnAndroid
            extraScrollHeight={20}
            keyboardShouldPersistTaps="handled"
        >
            <TouchableWithoutFeedback onPress={Keyboard.dismiss}>
                <BasicView className="flex-1 px-6 py-6 justify-center">

                    <BasicView className="mb-6">

                        <BasicText
                            variant="title"
                            className="text-center"
                            accessibilityRole="header"
                        >
                            Paswoord wijzigen
                        </BasicText>

                        <BasicText
                            className="text-center mt-1"
                            accessibilityLabel="Geef je huidig en nieuw paswoord in"
                        >
                            Geef je huidig en nieuw paswoord in
                        </BasicText>

                    </BasicView>

                    <CardView className="p-5 gap-5">

                        <View>
                            <BasicText accessibilityLabel="Huidig paswoord">
                                Huidig paswoord
                            </BasicText>

                            <TextInput
                                className={input(!!errors.currentPassword && !!touched.currentPassword)}
                                secureTextEntry
                                value={values.currentPassword}
                                onChangeText={handleChange('currentPassword')}
                                onBlur={handleBlur('currentPassword')}
                                returnKeyType="next"
                                onSubmitEditing={() => newPasswordRef.current?.focus()}
                                accessibilityLabel="Voer je huidig paswoord in"
                                accessibilityHint="Gebruik je huidig paswoord"
                            />

                            {touched.currentPassword && errors.currentPassword && (
                                <BasicText
                                    className="text-red-500"
                                    accessibilityLabel={errors.currentPassword}
                                >
                                    {errors.currentPassword}
                                </BasicText>
                            )}
                        </View>

                        <View>
                            <BasicText accessibilityLabel="Nieuw paswoord">
                                Nieuw paswoord
                            </BasicText>

                            <TextInput
                                ref={newPasswordRef}
                                className={input(!!errors.password && !!touched.password)}
                                secureTextEntry
                                value={values.password}
                                onChangeText={handleChange('password')}
                                onBlur={handleBlur('password')}
                                returnKeyType="next"
                                onSubmitEditing={() => confirmRef.current?.focus()}
                                accessibilityLabel="Voer nieuw paswoord in"
                                accessibilityHint="Minstens 6 karakters"
                            />

                            {touched.password && errors.password && (
                                <BasicText
                                    className="text-red-500"
                                    accessibilityLabel={errors.password}
                                >
                                    {errors.password}
                                </BasicText>
                            )}
                        </View>

                        <View>
                            <BasicText accessibilityLabel="Bevestig paswoord">
                                Bevestig nieuw paswoord
                            </BasicText>

                            <TextInput
                                ref={confirmRef}
                                className={input(!!errors.confirm && !!touched.confirm)}
                                secureTextEntry
                                value={values.confirm}
                                onChangeText={handleChange('confirm')}
                                onBlur={handleBlur('confirm')}
                                returnKeyType="done"
                                onSubmitEditing={() => handleSubmit()}
                                accessibilityLabel="Herhaal nieuw paswoord"
                            />

                            {touched.confirm && errors.confirm && (
                                <BasicText
                                    className="text-red-500"
                                    accessibilityLabel={errors.confirm}
                                >
                                    {errors.confirm}
                                </BasicText>
                            )}
                        </View>

                    </CardView>

                    <View className="mt-6">

                        <BasicButton
                            title={isSubmitting ? 'Bezig...' : 'Paswoord wijzigen'}
                            onPress={handleSubmit}
                            accessibilityRole="button"
                            accessibilityLabel="Paswoord wijzigen"
                            accessibilityHint="Wijzig je paswoord"
                        />

                    </View>

                </BasicView>
            </TouchableWithoutFeedback>
        </KeyboardAwareScrollView>
    )
}

export default PaswoordChangeScreen