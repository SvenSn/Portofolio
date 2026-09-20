import React, { useState, useEffect } from 'react'
import { TextInput, View, AccessibilityInfo } from 'react-native'
import { auth } from '../firebase'
import { signOut, updateProfile } from 'firebase/auth'
import BasicButton from '../components/BasicLayoutComponents/BasicButton'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import CardView from '../components/BasicLayoutComponents/CardView'
import { useNavigation } from '@react-navigation/native'
import { AccountStackNavProps } from '../navigators/types'
import * as Yup from 'yup'
import { useFormik } from 'formik'

const validationSchema = Yup.object().shape({
    gebruikersNaam: Yup.string()
        .min(3, "Minstens 3 karakters.")
        .required("Naam is verplicht"),
})

const AccountScreen = () => {
    const [isEditing, setIsEditing] = useState(false)
    const user = auth.currentUser

    const navigation =
        useNavigation<AccountStackNavProps<"accountsettings">["navigation"]>()

    const {
        handleSubmit,
        handleBlur,
        handleChange,
        values,
        errors,
        touched,
    } = useFormik({
        initialValues: {
            gebruikersNaam: user?.displayName || "",
        },
        validationSchema,
        onSubmit: async (values) => {
            if (!user) return

            try {
                await updateProfile(user, {
                    displayName: values.gebruikersNaam,
                })

                AccessibilityInfo.announceForAccessibility("Naam succesvol aangepast")

                setIsEditing(false)
            } catch (error) {
                console.log(error)
                AccessibilityInfo.announceForAccessibility("Fout bij aanpassen van naam")
            }
        },
    })

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility("Account informatie scherm")
    }, [])

    if (user?.isAnonymous) {
        return (
            <BasicView className="flex-1 px-6 justify-center">

                <CardView
                    className="p-6 gap-4"
                    accessible={true}
                    accessibilityLabel="Gastaccount. Je bent momenteel ingelogd als gast"
                >
                    <BasicText variant="title">
                        Gastaccount
                    </BasicText>

                    <BasicText
                        variant="label"
                        accessibilityLabel="Maak een account aan om je vooruitgang op te slaan"
                    >
                        Je bent momenteel ingelogd als gast. Maak een account aan om je vooruitgang op te slaan.
                    </BasicText>

                    <BasicButton
                        title="Loguit"
                        onPress={() => {
                            signOut(auth)
                            AccessibilityInfo.announceForAccessibility("Uitgelogd")
                        }}
                        accessibilityRole="button"
                        accessibilityLabel="Uitloggen"
                    />
                </CardView>

            </BasicView>
        )
    }

    return (
        <BasicView className="flex-1 px-6 py-6">

            <BasicView className="gap-4">

                <BasicText
                    variant="title"
                    accessibilityRole="header"
                >
                    Account informatie
                </BasicText>

                <CardView className="p-5 gap-3">

                    <BasicText accessibilityLabel="Naam">
                        Naam
                    </BasicText>

                    {!isEditing ? (
                        <>
                            <BasicText
                                accessibilityLabel={`Naam ${user?.displayName ?? "Niet ingesteld"}`}
                            >
                                {user?.displayName ?? "Niet ingesteld"}
                            </BasicText>

                            <BasicButton
                                title="Wijzig naam"
                                onPress={() => {
                                    setIsEditing(true)
                                    AccessibilityInfo.announceForAccessibility("Naam bewerken")
                                }}
                                accessibilityRole="button"
                                accessibilityLabel="Wijzig naam"
                            />
                        </>
                    ) : (
                        <>
                            <TextInput
                                className={`
                                    p-4 rounded-xl border
                                    bg-slate-100 dark:bg-slate-700
                                    text-slate-900 dark:text-slate-50
                                    ${touched.gebruikersNaam && errors.gebruikersNaam
                                        ? "border-red-500"
                                        : "border-slate-300 dark:border-slate-600"
                                    }
                                `}
                                value={values.gebruikersNaam}
                                onChangeText={handleChange("gebruikersNaam")}
                                onBlur={handleBlur("gebruikersNaam")}
                                placeholder="Nieuwe naam"
                                placeholderTextColor="#94a3b8"
                                accessibilityLabel="Voer nieuwe naam in"
                                accessibilityHint="Typ je nieuwe naam"
                            />

                            {touched.gebruikersNaam && errors.gebruikersNaam && (
                                <BasicText
                                    className="text-red-500 text-sm"
                                    accessibilityLabel={errors.gebruikersNaam}
                                >
                                    {errors.gebruikersNaam}
                                </BasicText>
                            )}

                            <View className="flex-row gap-3">

                                <BasicButton
                                    title="Opslaan"
                                    onPress={handleSubmit}
                                    accessibilityRole="button"
                                    accessibilityLabel="Naam opslaan"
                                />

                                <BasicButton
                                    title="Annuleer"
                                    onPress={() => {
                                        setIsEditing(false)
                                        AccessibilityInfo.announceForAccessibility("Bewerken geannuleerd")
                                    }}
                                    accessibilityRole="button"
                                    accessibilityLabel="Annuleer bewerken"
                                />

                            </View>
                        </>
                    )}

                    <BasicText accessibilityLabel="Email">
                        Email
                    </BasicText>

                    <BasicText
                        accessibilityLabel={`Email ${user?.email ?? "Geen email"}`}
                    >
                        {user?.email ?? "Geen email"}
                    </BasicText>

                </CardView>

                <View className="gap-3">

                    <BasicButton
                        title="Paswoord wijzigen"
                        onPress={() => {
                            navigation.navigate("paswoordChange")
                            AccessibilityInfo.announceForAccessibility("Ga naar paswoord wijzigen")
                        }}
                        accessibilityRole="button"
                        accessibilityLabel="Paswoord wijzigen"
                    />

                    <BasicButton
                        title="Uitloggen"
                        onPress={() => {
                            signOut(auth)
                            AccessibilityInfo.announceForAccessibility("Uitgelogd")
                        }}
                        accessibilityRole="button"
                        accessibilityLabel="Uitloggen"
                    />

                </View>

            </BasicView>

        </BasicView>
    )
}

export default AccountScreen