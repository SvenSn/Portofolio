import React from 'react'
import { createStackNavigator } from '@react-navigation/stack'
import { AuthStackParamslist } from './types';
import LoginScreen from '../screens/auth/LoginScreen';
import RegisterScreen from '../screens/auth/RegisterScreen';

const AuthStack = createStackNavigator<AuthStackParamslist>();

const AuthStackNavigator = () => {
    return (
        <AuthStack.Navigator>
            <AuthStack.Group screenOptions={{ headerShown: false }}>
                <AuthStack.Screen name='login' component={LoginScreen} />
                <AuthStack.Screen name='register' component={RegisterScreen} />
            </AuthStack.Group>
        </AuthStack.Navigator>
    )
}

export default AuthStackNavigator