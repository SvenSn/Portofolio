import React, { useRef, useState } from 'react'
import {
    KeyboardAvoidingView,
    Platform,
    ScrollView,
    TextInput,
    View,
} from 'react-native'
import {
    updateProfile,
    updatePassword,
    reauthenticateWithCredential,
    EmailAuthProvider,
    signOut,
} from 'firebase/auth'
import * as Yup from 'yup'
import { useFormik } from 'formik'
import BasicText from '../../components/BasicLayoutComponents/BasicText'
import BasicTextInput from '../../components/BasicLayoutComponents/BasicTextInput'
import BasicTouchableOpacity from '../../components/BasicLayoutComponents/BasicTouchAbleOpacity'
import BasicView from '../../components/BasicLayoutComponents/BasicView'
import { auth } from '../../config/firebase'

const displayNameValidationSchema = Yup.object().shape({
    displayName: Yup.string()
        .min(3, 'Minimum 3 characters')
        .required('Display name is required'),
})

const passwordValidationSchema = Yup.object().shape({
    currentPassword: Yup.string()
        .required('Current password is required'),
    newPassword: Yup.string()
        .min(6, 'Password must be at least 6 characters')
        .required('New password is required'),
    confirmPassword: Yup.string()
        .oneOf([Yup.ref('newPassword')], 'Passwords do not match')
        .required('Confirm password is required'),
})

const AccountSettings = () => {
    const user = auth.currentUser

    const displayNameRef = useRef<TextInput>(null)
    const currentPasswordRef = useRef<TextInput>(null)
    const newPasswordRef = useRef<TextInput>(null)
    const confirmPasswordRef = useRef<TextInput>(null)

    const [isEditingName, setIsEditingName] = useState(false)
    const [isEditingPassword, setIsEditingPassword] = useState(false)
    const [passwordMessage, setPasswordMessage] = useState('')
    const [passwordError, setPasswordError] = useState('')

    const displayNameForm = useFormik({
        initialValues: {
            displayName: user?.displayName || '',
        },
        validationSchema: displayNameValidationSchema,
        onSubmit: async (values) => {
            if (!user) return

            try {
                await updateProfile(user, {
                    displayName: values.displayName,
                })

                setIsEditingName(false)
            } catch (error) {
                console.log(error)
            }
        },
    })

    const passwordForm = useFormik({
        initialValues: {
            currentPassword: '',
            newPassword: '',
            confirmPassword: '',
        },
        validationSchema: passwordValidationSchema,
        onSubmit: async (values, { resetForm }) => {
            if (!user || !user.email) return

            setPasswordMessage('')
            setPasswordError('')

            try {
                const credential = EmailAuthProvider.credential(
                    user.email,
                    values.currentPassword
                )

                await reauthenticateWithCredential(user, credential)
                await updatePassword(user, values.newPassword)

                resetForm()
                setIsEditingPassword(false)
                setPasswordMessage('Password updated successfully')
            } catch (error) {
                console.log(error)
                setPasswordError('Current password is incorrect or something went wrong')
            }
        },
    })

    const handleLogout = async () => {
        try {
            await signOut(auth)
        } catch (error) {
            console.log(error)
        }
    }

    return (
        <KeyboardAvoidingView
            className="flex-1 bg-white dark:bg-neutral-900"
            behavior={Platform.OS === 'ios' ? 'padding' : 'height'}
            keyboardVerticalOffset={Platform.OS === 'ios' ? 80 : 0}
        >
            <ScrollView
                className="flex-1"
                keyboardShouldPersistTaps="handled"
                showsVerticalScrollIndicator={false}
            >
                <View className="flex-grow px-6 py-10 pb-20 gap-8">
                    <BasicView className="gap-3 flex-none bg-transparent">

                        <BasicText variant="label">
                            Display Name
                        </BasicText>

                        {!isEditingName ? (
                            <>
                                <BasicText>
                                    {user?.displayName || 'No display name set'}
                                </BasicText>

                                <BasicTouchableOpacity
                                    className="w-auto px-6"
                                    onPress={() => setIsEditingName(true)}
                                    variant="secondary"
                                >
                                    Edit Display Name
                                </BasicTouchableOpacity>
                            </>
                        ) : (
                            <>
                                <BasicTextInput
                                    ref={displayNameRef}
                                    label="New Display Name"
                                    value={displayNameForm.values.displayName}
                                    onChangeText={displayNameForm.handleChange('displayName')}
                                    onBlur={displayNameForm.handleBlur('displayName')}
                                    error={
                                        displayNameForm.touched.displayName
                                            ? displayNameForm.errors.displayName
                                            : undefined
                                    }
                                    placeholder="Enter a new display name"
                                    returnKeyType="done"
                                    onSubmitEditing={() => displayNameForm.handleSubmit()}
                                />

                                <BasicView className="flex-none gap-3 bg-transparent">
                                    <BasicTouchableOpacity
                                        onPress={() => displayNameForm.handleSubmit()}
                                    >
                                        Save
                                    </BasicTouchableOpacity>

                                    <BasicTouchableOpacity
                                        variant="secondary"
                                        onPress={() => setIsEditingName(false)}
                                    >
                                        Cancel
                                    </BasicTouchableOpacity>
                                </BasicView>
                            </>
                        )}

                    </BasicView>

                    <BasicView className="gap-2 flex-none bg-transparent">

                        <BasicText variant="label">
                            Email
                        </BasicText>

                        <BasicText>
                            {user?.email}
                        </BasicText>

                    </BasicView>

                    <BasicView className="gap-3 flex-none bg-transparent">

                        <BasicText variant="label">
                            Password
                        </BasicText>

                        {passwordMessage ? (
                            <BasicText variant="caption" className="text-green-600 dark:text-green-400">
                                {passwordMessage}
                            </BasicText>
                        ) : null}

                        {passwordError ? (
                            <BasicText variant="caption" className="text-red-500 dark:text-red-400">
                                {passwordError}
                            </BasicText>
                        ) : null}

                        {!isEditingPassword ? (
                            <BasicTouchableOpacity
                                variant="secondary"
                                onPress={() => {
                                    setPasswordMessage('')
                                    setPasswordError('')
                                    setIsEditingPassword(true)

                                    setTimeout(() => {
                                        currentPasswordRef.current?.focus()
                                    }, 100)
                                }}
                            >
                                Change Password
                            </BasicTouchableOpacity>
                        ) : (
                            <>
                                <BasicTextInput
                                    ref={currentPasswordRef}
                                    label="Current Password"
                                    value={passwordForm.values.currentPassword}
                                    onChangeText={passwordForm.handleChange('currentPassword')}
                                    onBlur={passwordForm.handleBlur('currentPassword')}
                                    error={
                                        passwordForm.touched.currentPassword
                                            ? passwordForm.errors.currentPassword
                                            : undefined
                                    }
                                    placeholder="Enter current password"
                                    secureTextEntry
                                    returnKeyType="next"
                                    onSubmitEditing={() => newPasswordRef.current?.focus()}
                                />

                                <BasicTextInput
                                    ref={newPasswordRef}
                                    label="New Password"
                                    value={passwordForm.values.newPassword}
                                    onChangeText={passwordForm.handleChange('newPassword')}
                                    onBlur={passwordForm.handleBlur('newPassword')}
                                    error={
                                        passwordForm.touched.newPassword
                                            ? passwordForm.errors.newPassword
                                            : undefined
                                    }
                                    placeholder="Enter new password"
                                    secureTextEntry
                                    returnKeyType="next"
                                    onSubmitEditing={() => confirmPasswordRef.current?.focus()}
                                />

                                <BasicTextInput
                                    ref={confirmPasswordRef}
                                    label="Confirm Password"
                                    value={passwordForm.values.confirmPassword}
                                    onChangeText={passwordForm.handleChange('confirmPassword')}
                                    onBlur={passwordForm.handleBlur('confirmPassword')}
                                    error={
                                        passwordForm.touched.confirmPassword
                                            ? passwordForm.errors.confirmPassword
                                            : undefined
                                    }
                                    placeholder="Confirm new password"
                                    secureTextEntry
                                    returnKeyType="done"
                                    onSubmitEditing={() => passwordForm.handleSubmit()}
                                />

                                <BasicView className="flex-none gap-3 bg-transparent">
                                    <BasicTouchableOpacity
                                        onPress={() => passwordForm.handleSubmit()}
                                    >
                                        Save Password
                                    </BasicTouchableOpacity>

                                    <BasicTouchableOpacity
                                        variant="secondary"
                                        onPress={() => {
                                            passwordForm.resetForm()
                                            setPasswordError('')
                                            setIsEditingPassword(false)
                                        }}
                                    >
                                        Cancel
                                    </BasicTouchableOpacity>
                                </BasicView>
                            </>
                        )}

                    </BasicView>

                    <BasicView className="flex-none gap-3 bg-transparent pt-4">
                        <BasicTouchableOpacity
                            variant="destructive"
                            onPress={handleLogout}
                        >
                            Logout
                        </BasicTouchableOpacity>
                    </BasicView>

                </View>
            </ScrollView>
        </KeyboardAvoidingView>
    )
}

export default AccountSettings