import React from 'react';
import { createDrawerNavigator } from '@react-navigation/drawer';
import { useTheme } from '@react-navigation/native';

import { InstellingenDrawersParamsList } from './types';
import StepsStatsScreen from '../screens/StepsStatsScreen';
import SettingsScreen from '../screens/SettingsScreen';
import AccountSettings from '../screens/auth/AccountSettings';
import AboutScreen from '../screens/AboutScreen';

const Drawer = createDrawerNavigator<InstellingenDrawersParamsList>();

const InstellingenDrawerNavigator = () => {
    const { colors } = useTheme();

    return (
        <Drawer.Navigator
        >
            <Drawer.Screen
                name="About"
                component={AboutScreen}
                options={{ title: 'About Us' }}
            />

            <Drawer.Screen
                name="Account"
                component={AccountSettings}
                options={{ title: 'Account Settings' }}
            />

            <Drawer.Screen
                name="StepStats"
                component={StepsStatsScreen}
                options={{ title: 'Steps' }}
            />

            <Drawer.Screen
                name="Settings"
                component={SettingsScreen}
                options={{ title: 'Settings' }}
            />
        </Drawer.Navigator>
    );
};

export default InstellingenDrawerNavigator;