import { View, Text } from 'react-native'
import React from 'react'
import { createStackNavigator } from '@react-navigation/stack'
import { AuthStackParamsList } from './types'
import LoginScreen from '../screens/auth/LoginScreen';
import RegisterScreen from '../screens/auth/RegisterScreen';


const AuthStack = createStackNavigator<AuthStackParamsList>();

const AuthStackNavigator = () => {
    return (
        <AuthStack.Navigator screenOptions={{ headerShown: true, headerTitleAlign: 'center' }}>
            <AuthStack.Group screenOptions={{
                headerShown: false
            }}>
                <AuthStack.Screen name='Login' component={LoginScreen} />
                <AuthStack.Screen name='Register' component={RegisterScreen} />
            </AuthStack.Group>
        </AuthStack.Navigator>
    )
}

export default AuthStackNavigator