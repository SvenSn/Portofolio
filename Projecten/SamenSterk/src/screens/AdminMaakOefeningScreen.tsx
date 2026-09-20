import React from 'react'
import { ScrollView, TextInput, TouchableOpacity, View, Alert } from 'react-native'
import * as Yup from 'yup'
import { useFormik } from 'formik'
import { addDoc, collection } from 'firebase/firestore'
import { db } from '../firebase'
import { EXERCISE_TYPES, ExerciseType, ExerciseStep } from '../types/shared'
import CardView from '../components/BasicLayoutComponents/CardView'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicButton from '../components/BasicLayoutComponents/BasicButton'
import { useNavigation } from '@react-navigation/native'
import { useGebruiker } from '../hooks/useGebruiker'

type NewExercise = {
    name: string
    type: ExerciseType
    KorteBeschrijving: string
    LangeBeschrijving: string
    steps: ExerciseStep[]
}

const validationSchema = Yup.object().shape({
    name: Yup.string().min(2, 'Minstens 2 karakters').required('Naam verplicht'),
    type: Yup.mixed<ExerciseType>().oneOf(EXERCISE_TYPES as unknown as ExerciseType[], 'Kies een type').required('Type verplicht'),
    KorteBeschrijving: Yup.string().min(5, 'Minstens 5 karakters').required('Kort verplicht'),
    LangeBeschrijving: Yup.string().min(10, 'Minstens 10 karakters').required('Lang verplicht'),
    steps: Yup.array()
        .of(
            Yup.object().shape({
                beschrijving: Yup.string().min(2, 'Minstens 2 karakters').required('Stap beschrijving verplicht'),
                imageUrl: Yup.string().url('Ongeldige URL'),
            })
        )
        .min(1, 'Minstens 1 stap is verplicht')
        .required(),
})

const AdminMaakOefeningScreen = () => {
    const navigation = useNavigation()
    const { isAdmin } = useGebruiker()

    const {
        values,
        errors,
        touched,
        handleChange,
        handleBlur,
        handleSubmit,
        setFieldValue,
        setFieldTouched,
    } = useFormik<NewExercise>({
        initialValues: {
            name: '',
            type: 'arm',
            KorteBeschrijving: '',
            LangeBeschrijving: '',
            steps: [{ order: 1, beschrijving: '', imageUrl: '' }],
        },
        validationSchema,
        validateOnBlur: true,
        validateOnChange: false,
        onSubmit: async (values) => {
            if (!isAdmin) {
                Alert.alert('Geen toegang')
                return
            }

            const exercise = {
                name: values.name.trim(),
                type: values.type,
                KorteBeschrijving: values.KorteBeschrijving.trim(),
                LangeBeschrijving: values.LangeBeschrijving.trim(),
                steps: values.steps.map((s, i) => ({
                    order: i + 1,
                    beschrijving: s.beschrijving.trim(),
                    imageUrl: s.imageUrl.trim(),
                })),
            }

            await addDoc(collection(db, 'Oefeningen'), exercise)

            Alert.alert('Opgeslagen')
            navigation.goBack()
        },
    })

    const input = (error?: boolean) => `
        px-4 py-3 rounded-2xl border
        bg-slate-100 dark:bg-slate-700
        text-slate-900 dark:text-slate-50
        ${error ? 'border-red-500' : 'border-slate-300 dark:border-slate-600'}
    `

    const addStep = () => {
        setFieldValue('steps', [
            ...values.steps,
            { order: values.steps.length + 1, beschrijving: '', imageUrl: '' },
        ])
    }

    const updateStepField = (index: number, field: 'beschrijving' | 'imageUrl', value: string) => {
        const updated = [...values.steps]
        updated[index] = { ...updated[index], [field]: value }
        setFieldValue('steps', updated)
    }

    const removeStep = (index: number) => {
        const updated = values.steps
            .filter((_, i) => i !== index)
            .map((s, i) => ({ ...s, order: i + 1 }))
        setFieldValue('steps', updated)
    }

    if (!isAdmin) return null

    return (
        <ScrollView
            className="flex-1"
            showsVerticalScrollIndicator={false}
            contentContainerClassName="p-4 gap-5 pb-10"
        >
            <BasicText variant="title">Nieuwe oefening</BasicText>

            <CardView className="p-5 gap-4">
                <View>
                    <BasicText variant="label" className="mb-1">Naam</BasicText>
                    <TextInput
                        placeholder="Naam"
                        placeholderTextColor="#94a3b8"
                        value={values.name}
                        onChangeText={handleChange('name')}
                        onBlur={handleBlur('name')}
                        className={input(!!errors.name && !!touched.name)}
                    />
                    {touched.name && errors.name && (
                        <BasicText className="text-red-500 text-sm mt-1">{errors.name}</BasicText>
                    )}
                </View>

                <View>
                    <BasicText variant="label" className="mb-1">Korte beschrijving</BasicText>
                    <TextInput
                        placeholder="Korte beschrijving"
                        placeholderTextColor="#94a3b8"
                        value={values.KorteBeschrijving}
                        onChangeText={handleChange('KorteBeschrijving')}
                        onBlur={handleBlur('KorteBeschrijving')}
                        className={input(!!errors.KorteBeschrijving && !!touched.KorteBeschrijving)}
                    />
                    {touched.KorteBeschrijving && errors.KorteBeschrijving && (
                        <BasicText className="text-red-500 text-sm mt-1">{errors.KorteBeschrijving}</BasicText>
                    )}
                </View>

                <View>
                    <BasicText variant="label" className="mb-1">Lange beschrijving</BasicText>
                    <TextInput
                        placeholder="Lange beschrijving"
                        placeholderTextColor="#94a3b8"
                        value={values.LangeBeschrijving}
                        onChangeText={handleChange('LangeBeschrijving')}
                        onBlur={handleBlur('LangeBeschrijving')}
                        multiline
                        className={input(!!errors.LangeBeschrijving && !!touched.LangeBeschrijving)}
                    />
                    {touched.LangeBeschrijving && errors.LangeBeschrijving && (
                        <BasicText className="text-red-500 text-sm mt-1">{errors.LangeBeschrijving}</BasicText>
                    )}
                </View>
            </CardView>

            <CardView className="p-5 gap-3">
                <BasicText variant="label">Type</BasicText>

                <View className="flex-row flex-wrap gap-2">
                    {EXERCISE_TYPES.map((t) => (
                        <TouchableOpacity key={t} activeOpacity={0.7} onPress={() => setFieldValue('type', t)}>
                            <CardView
                                className={`
                                    px-4 py-2 rounded-full
                                    ${values.type === t
                                        ? 'bg-sky-600 border border-sky-700'
                                        : 'bg-white dark:bg-slate-800 border border-slate-200 dark:border-slate-700'
                                    }
                                `}
                            >
                                <BasicText className={`text-sm font-semibold capitalize ${values.type === t ? 'text-white' : 'text-slate-600 dark:text-slate-300'}`}>
                                    {t}
                                </BasicText>
                            </CardView>
                        </TouchableOpacity>
                    ))}
                </View>

                {touched.type && (errors.type as any) && (
                    <BasicText className="text-red-500 text-sm mt-1">{errors.type as any}</BasicText>
                )}
            </CardView>

            <CardView className="p-5 gap-4">
                <BasicText variant="label">Stappen</BasicText>

                {values.steps.map((step, index) => {
                    const stepErrors: any = (errors.steps as any)?.[index]
                    const stepTouched: any = (touched.steps as any)?.[index]

                    return (
                        <CardView
                            key={index}
                            className="p-4 gap-3 border border-slate-200 dark:border-slate-700"
                        >
                            <BasicText className="font-semibold">
                                Stap {index + 1}
                            </BasicText>

                            <View>
                                <BasicText variant="label" className="mb-1">Beschrijving</BasicText>
                                <TextInput
                                    placeholder="Beschrijving"
                                    placeholderTextColor="#94a3b8"
                                    value={step.beschrijving}
                                    onChangeText={(text) => updateStepField(index, 'beschrijving', text)}
                                    onBlur={() => setFieldTouched(`steps.${index}.beschrijving`, true)}
                                    multiline
                                    className={input(!!(stepTouched?.beschrijving && stepErrors?.beschrijving))}
                                />
                                {stepTouched?.beschrijving && stepErrors?.beschrijving && (
                                    <BasicText className="text-red-500 text-sm mt-1">{String(stepErrors.beschrijving)}</BasicText>
                                )}
                            </View>

                            <View>
                                <BasicText variant="label" className="mb-1">Afbeelding URL</BasicText>
                                <TextInput
                                    placeholder="https://..."
                                    placeholderTextColor="#94a3b8"
                                    value={step.imageUrl}
                                    onChangeText={(text) => updateStepField(index, 'imageUrl', text)}
                                    onBlur={() => setFieldTouched(`steps.${index}.imageUrl`, true)}
                                    autoCapitalize="none"
                                    autoCorrect={false}
                                    className={input(!!(stepTouched?.imageUrl && stepErrors?.imageUrl))}
                                />
                                {stepTouched?.imageUrl && stepErrors?.imageUrl && (
                                    <BasicText className="text-red-500 text-sm mt-1">{String(stepErrors.imageUrl)}</BasicText>
                                )}
                            </View>

                            {values.steps.length > 1 && (
                                <BasicButton title="Verwijder stap" onPress={() => removeStep(index)} />
                            )}
                        </CardView>
                    )
                })}

                {typeof errors.steps === 'string' && (
                    <BasicText className="text-red-500 text-sm">{errors.steps}</BasicText>
                )}

                <BasicButton title="+ Stap toevoegen" onPress={addStep} />
            </CardView>

            <BasicButton title="Opslaan" onPress={handleSubmit} />
        </ScrollView>
    )
}

export default AdminMaakOefeningScreen