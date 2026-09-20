import React from 'react'
import { createStackNavigator } from '@react-navigation/stack'
import { AccountStackParamsList } from './types'
import AccountScreen from '../screens/AccountScreen';
import PaswoordChangeScreen from '../screens/auth/PaswoordChangeScreen';

const AccStack = createStackNavigator<AccountStackParamsList>();

const AccountStackNavigator = () => {
    return (
        <AccStack.Navigator>
            <AccStack.Screen name='accountsettings' options={{ headerShown: false }} component={AccountScreen} />
            <AccStack.Screen name='paswoordChange' options={{ title: "Wachtwoord wijzigen" }} component={PaswoordChangeScreen} />
        </AccStack.Navigator>
    )
}

export default AccountStackNavigator