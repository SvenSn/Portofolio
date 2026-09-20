import { View, Text } from 'react-native'
import React from 'react'
import { createDrawerNavigator } from '@react-navigation/drawer'
import { SettingsDrawerParamsList } from './types'
import AboutScreen from '../screens/AboutScreen';
import AccountScreen from '../screens/AccountScreen';
import AccountStackNavigator from './AccountStackNavigator';
import ToegangkelijkheidScreen from '../screens/ToegangkelijkheidScreen';


const Drawer = createDrawerNavigator<SettingsDrawerParamsList>();

const SettingsDrawerNavigator = () => {
    return (
        <Drawer.Navigator>
            <Drawer.Screen name='about' component={AboutScreen} options={{ title: "About" }} />
            <Drawer.Screen name='account' component={AccountStackNavigator} options={{ title: "Account" }} />
            <Drawer.Screen name='toegangkelijkheid' component={ToegangkelijkheidScreen} options={{ title: "Toegangkelijkheid" }} />
        </Drawer.Navigator>
    )
}

export default SettingsDrawerNavigator