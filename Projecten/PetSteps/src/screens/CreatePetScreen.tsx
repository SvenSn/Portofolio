import React, { useState } from 'react'
import { ActivityIndicator, Image, ScrollView } from 'react-native'
import { useFormik } from 'formik'
import * as Yup from 'yup'
import { useNavigation } from '@react-navigation/native'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicTextInput from '../components/BasicLayoutComponents/BasicTextInput'
import BasicTouchableOpacity from '../components/BasicLayoutComponents/BasicTouchAbleOpacity'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import { auth } from '../config/firebase'
import { useAppDispatch } from '../hooks/ReduxHooks'
import { PetType, PET_TYPES } from '../types'
import { useCloudinaryUpload } from '../hooks/useCloudinaryUpload'
import { createPet } from '../service/PetService'

const validationSchema = Yup.object().shape({
    name: Yup.string()
        .min(2, 'Name must be at least 2 characters')
        .max(20, 'Name must be at most 20 characters')
        .required('Name is required'),
    type: Yup.mixed<PetType>()
        .oneOf([...PET_TYPES], 'Invalid type')
        .required('Type is required'),
})

const CreatePetScreen = () => {
    const dispatch = useAppDispatch()
    const navigation = useNavigation()
    const user = auth.currentUser

    const { pickImage, uploadImage, isUploading, error: uploadError } =
        useCloudinaryUpload()

    const [selectedImageUri, setSelectedImageUri] = useState('')
    const [imageError, setImageError] = useState('')

    const {
        handleChange,
        handleBlur,
        handleSubmit,
        values,
        errors,
        touched,
        setFieldValue,
    } = useFormik({
        initialValues: {
            name: '',
            type: '' as PetType,
        },
        validationSchema,
        onSubmit: async (values) => {
            if (!user) return

            if (!selectedImageUri) {
                setImageError('Image is required')
                return
            }

            setImageError('')

            try {
                const imageUrl = await uploadImage(selectedImageUri)

                if (!imageUrl) {
                    setImageError('Image upload failed')
                    return
                }

            
                    await createPet(user.uid, values.name, values.type, imageUrl)

                navigation.navigate('petList' as never)
            } catch (error) {
                console.log('Create pet error:', error)
            }
        },
    })

    const handleChooseImage = async () => {
        const uri = await pickImage()

        if (!uri) {
            setImageError('No image selected')
            return
        }

        setSelectedImageUri(uri)
        setImageError('')
    }

    return (
        <ScrollView
            className="flex-1 bg-white dark:bg-neutral-900"
            keyboardShouldPersistTaps="handled"
            showsVerticalScrollIndicator={false}
        >
            <BasicView className="flex-1 justify-center px-6 py-10 gap-8 bg-transparent">

                <BasicView className="flex-none gap-1 bg-transparent">
                    <BasicText variant="heading" className="text-center">
                        New Pet
                    </BasicText>

                    <BasicText variant="secondary" className="text-center">
                        Create your pet
                    </BasicText>
                </BasicView>

                <BasicView className="flex-none gap-4 bg-transparent">

                    <BasicTextInput
                        label="Name"
                        placeholder="Buddy"
                        onChangeText={handleChange('name')}
                        onBlur={handleBlur('name')}
                        value={values.name}
                        error={touched.name ? errors.name : undefined}
                        returnKeyType="next"
                    />

                    <BasicView className="flex-none gap-1 bg-transparent">
                        <BasicText variant="label">
                            Type
                        </BasicText>

                        <BasicView className="flex-none flex-row gap-2 bg-transparent">
                            {[...PET_TYPES].map((type) => (
                                <BasicTouchableOpacity
                                    key={type}
                                    variant={values.type === type ? 'primary' : 'secondary'}
                                    className="flex-1 py-3"
                                    onPress={() => setFieldValue('type', type)}
                                >
                                    {type}
                                </BasicTouchableOpacity>
                            ))}
                        </BasicView>

                        {touched.type && errors.type ? (
                            <BasicText variant="caption" className="text-red-500 dark:text-red-400">
                                {errors.type}
                            </BasicText>
                        ) : null}
                    </BasicView>

                    <BasicView className="flex-none gap-3 bg-transparent">
                        <BasicText variant="label">
                            Image
                        </BasicText>

                        {selectedImageUri ? (
                            <Image
                                source={{ uri: selectedImageUri }}
                                className="h-44 w-full rounded-2xl bg-neutral-100 dark:bg-neutral-800"
                                resizeMode="cover"
                            />
                        ) : (
                            <BasicView className="flex-none h-44 items-center justify-center rounded-2xl border border-dashed border-neutral-300 bg-neutral-50 dark:border-neutral-700 dark:bg-neutral-900">
                                <BasicText variant="caption">
                                    No image selected
                                </BasicText>
                            </BasicView>
                        )}

                        {isUploading ? (
                            <BasicView className="flex-none items-center gap-2 bg-transparent py-2">
                                <ActivityIndicator size="small" />
                                <BasicText variant="caption">
                                    Uploading image...
                                </BasicText>
                            </BasicView>
                        ) : null}

                        {imageError ? (
                            <BasicText variant="caption" className="text-red-500 dark:text-red-400">
                                {imageError}
                            </BasicText>
                        ) : null}

                        {uploadError ? (
                            <BasicText variant="caption" className="text-red-500 dark:text-red-400">
                                {uploadError}
                            </BasicText>
                        ) : null}

                        <BasicTouchableOpacity
                            variant="secondary"
                            onPress={handleChooseImage}
                            disabled={isUploading}
                        >
                            {selectedImageUri ? 'Change image' : 'Choose image'}
                        </BasicTouchableOpacity>
                    </BasicView>

                </BasicView>

                <BasicView className="flex-none gap-3 bg-transparent">
                    <BasicTouchableOpacity
                        onPress={() => handleSubmit()}
                        disabled={isUploading}
                    >
                        {isUploading ? 'Creating pet...' : 'Create pet'}
                    </BasicTouchableOpacity>

                    <BasicTouchableOpacity
                        variant="ghost"
                        onPress={() => navigation.goBack()}
                        disabled={isUploading}
                    >
                        Cancel
                    </BasicTouchableOpacity>
                </BasicView>

            </BasicView>
        </ScrollView>
    )
}

export default CreatePetScreen