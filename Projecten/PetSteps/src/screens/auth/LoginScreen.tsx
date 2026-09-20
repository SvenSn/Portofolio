import React, { useRef } from 'react'
import { TextInput } from 'react-native'
import { useFormik } from 'formik'
import * as Yup from 'yup'
import { signInWithEmailAndPassword } from 'firebase/auth'
import { auth } from '../../config/firebase'
import BasicView from '../../components/BasicLayoutComponents/BasicView'
import BasicText from '../../components/BasicLayoutComponents/BasicText'
import BasicTextInput from '../../components/BasicLayoutComponents/BasicTextInput'
import BasicTouchableOpacity from '../../components/BasicLayoutComponents/BasicTouchAbleOpacity'
import { useNavigation } from '@react-navigation/native'
import { AuthStackNavProps } from '../../navigators/types'

const validationSchema = Yup.object().shape({
    email: Yup.string().email('Invalid email address').required('Email is required'),
    password: Yup.string().required('Password is required'),
})

const LoginScreen = () => {
    const passwordRef = useRef<TextInput>(null)
    const navigation = useNavigation<AuthStackNavProps<"login">["navigation"]>();
    const { handleChange, handleBlur, handleSubmit, values, errors } = useFormik({
        initialValues: {
            email: '',
            password: '',
        },
        validationSchema,
        onSubmit: async (values) => {
            try {
                await signInWithEmailAndPassword(auth, values.email, values.password);
            } catch (error) {
                console.log(error)
            }
        },
    })

    return (
        <BasicView className="flex-1 justify-center px-6 gap-8">
            <BasicView className="flex-none gap-1">
                <BasicText variant="heading" className="text-center">Welcome back</BasicText>
                <BasicText variant="secondary" className="text-center">Pet Steps</BasicText>
            </BasicView>
            <BasicView className="flex-none gap-4">
                <BasicTextInput
                    label="Email"
                    placeholder="your@email.com"
                    onChangeText={handleChange('email')}
                    onBlur={handleBlur('email')}
                    value={values.email}
                    keyboardType="email-address"
                    submitBehavior="submit"
                    returnKeyType="next"
                    error={errors.email}
                    onSubmitEditing={() => passwordRef.current?.focus()}
                />
                <BasicTextInput
                    label="Password"
                    placeholder="••••••••"
                    onChangeText={handleChange('password')}
                    onBlur={handleBlur('password')}
                    value={values.password}
                    secureTextEntry
                    returnKeyType="done"
                    error={errors.password}
                    ref={passwordRef}
                    onSubmitEditing={() => handleSubmit()}
                />
            </BasicView>
            <BasicView className="flex-none gap-3">
                <BasicTouchableOpacity onPress={() => handleSubmit()}>
                    Sign in
                </BasicTouchableOpacity>
                <BasicTouchableOpacity variant="ghost" onPress={() => { navigation.replace("register"); }}>
                    Don't have an account? Sign up
                </BasicTouchableOpacity>
            </BasicView>
        </BasicView>
    )
}

export default LoginScreen