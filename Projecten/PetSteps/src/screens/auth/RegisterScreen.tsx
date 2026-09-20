import React, { useRef } from 'react'
import { TextInput } from 'react-native'
import { useFormik } from 'formik'
import * as Yup from 'yup'
import { createUserWithEmailAndPassword, updateProfile } from 'firebase/auth'
import { auth } from '../../config/firebase'
import BasicView from '../../components/BasicLayoutComponents/BasicView'
import BasicText from '../../components/BasicLayoutComponents/BasicText'
import BasicTextInput from '../../components/BasicLayoutComponents/BasicTextInput'
import BasicTouchableOpacity from '../../components/BasicLayoutComponents/BasicTouchAbleOpacity'
import { useNavigation } from '@react-navigation/native'
import { AuthStackNavProps } from '../../navigators/types'

const validationSchema = Yup.object().shape({
    displayName: Yup.string()
        .min(2, 'Name must be at least 2 characters')
        .required('Name is required'),
    email: Yup.string()
        .email('Invalid email address')
        .required('Email is required'),
    password: Yup.string()
        .min(6, 'Password must be at least 6 characters')
        .required('Password is required'),
    confirmPassword: Yup.string()
        .oneOf([Yup.ref('password')], 'Passwords do not match')
        .required('Please confirm your password'),
})

const RegisterScreen = () => {
    const emailRef = useRef<TextInput>(null)
    const passwordRef = useRef<TextInput>(null)
    const confirmPasswordRef = useRef<TextInput>(null)
    const navigation = useNavigation<AuthStackNavProps<"register">["navigation"]>();

    const { handleChange, handleBlur, handleSubmit, values, errors } = useFormik({
        initialValues: {
            displayName: '',
            email: '',
            password: '',
            confirmPassword: '',
        },
        validationSchema,
        onSubmit: async (values) => {
            try {
                const { user } = await createUserWithEmailAndPassword(auth, values.email, values.password)
                await updateProfile(user, { displayName: values.displayName })
            } catch (error) {
                console.log(error)
            }
        },
    })

    return (
        <BasicView className="flex-1 justify-center px-6 gap-8">
            <BasicView className="flex-none gap-1">
                <BasicText variant="heading" className="text-center">Create account</BasicText>
                <BasicText variant="secondary" className="text-center">Pet Steps</BasicText>
            </BasicView>

            <BasicView className="flex-none gap-4">
                <BasicTextInput
                    label="Name"
                    placeholder="John Doe"
                    onChangeText={handleChange('displayName')}
                    onBlur={handleBlur('displayName')}
                    value={values.displayName}
                    returnKeyType="next"
                    error={errors.displayName}
                    onSubmitEditing={() => emailRef.current?.focus()}
                />
                <BasicTextInput
                    label="Email"
                    placeholder="your@email.com"
                    onChangeText={handleChange('email')}
                    onBlur={handleBlur('email')}
                    value={values.email}
                    keyboardType="email-address"
                    returnKeyType="next"
                    error={errors.email}
                    ref={emailRef}
                    onSubmitEditing={() => passwordRef.current?.focus()}
                />
                <BasicTextInput
                    label="Password"
                    placeholder="••••••••"
                    onChangeText={handleChange('password')}
                    onBlur={handleBlur('password')}
                    value={values.password}
                    secureTextEntry
                    returnKeyType="next"
                    error={errors.password}
                    ref={passwordRef}
                    onSubmitEditing={() => confirmPasswordRef.current?.focus()}
                />
                <BasicTextInput
                    label="Confirm password"
                    placeholder="••••••••"
                    onChangeText={handleChange('confirmPassword')}
                    onBlur={handleBlur('confirmPassword')}
                    value={values.confirmPassword}
                    secureTextEntry
                    returnKeyType="done"
                    error={errors.confirmPassword}
                    ref={confirmPasswordRef}
                    onSubmitEditing={() => handleSubmit()}
                />
            </BasicView>
            <BasicView className="flex-none gap-3">
                <BasicTouchableOpacity onPress={() => handleSubmit()}>
                    Create account
                </BasicTouchableOpacity>
                <BasicTouchableOpacity variant="ghost" onPress={() => { navigation.replace("login"); }}>
                    Already have an account? Sign in
                </BasicTouchableOpacity>
            </BasicView>

        </BasicView>
    )
}

export default RegisterScreen