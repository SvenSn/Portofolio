import { View, Text } from 'react-native'
import React from 'react'
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import { SamenSterkTabNavProps, SamenSterkTabParamsList } from './types'
import PuzzelScreen from '../screens/PuzzelScreen';
import MaterialCommunityIcons from '@expo/vector-icons/MaterialCommunityIcons';
import FontAwesome5 from '@expo/vector-icons/FontAwesome5';
import OefeningenScreen from '../screens/OefeningenScreen';
import InstellingenScreen from '../screens/InstellingenScreen';
import KalenderScreen from '../screens/KalenderScreen';
import OefeningenStackNavigator from './OefeningenStackNavigator';
import PuzzelStackNavigator from './PuzzelStackNavigator';
import { useAppSelector } from '../hooks/ReduxHooks'
import SettingsDrawerNavigator from './SettingsDrawerNavigator';

const SamenSterkTab = createBottomTabNavigator<SamenSterkTabParamsList>();

const SamenSterkTabNavigator = () => {
    const darkMode = useAppSelector(state => state.accountSettings.darkMode)
    return (

        <SamenSterkTab.Navigator
            screenOptions={{
                tabBarLabelStyle: { fontSize: 14, fontWeight: '600' },

                tabBarActiveTintColor: darkMode ? '#60a5fa' : '#2563eb',
                tabBarInactiveTintColor: darkMode ? '#94a3b8' : '#64748b',

                tabBarStyle: {
                    backgroundColor: darkMode ? '#1e293b' : '#ffffff',
                    borderTopColor: darkMode ? '#334155' : '#e2e8f0',
                }
            }}
        >
            <SamenSterkTab.Screen name='OefeningenStack' component={OefeningenStackNavigator} options={
                {
                    title: "Oefeningen",
                    headerTitleAlign: 'center',
                    headerShown: false,
                    tabBarIcon: ({ color, size }) => (
                        <MaterialCommunityIcons name="weight-lifter" size={size} color={color} />
                    )
                }
            } />
            <SamenSterkTab.Screen name='PuzzelStack' component={PuzzelStackNavigator} options={
                {
                    title: "Puzzels",
                    headerTitleAlign: 'center',
                    headerShown: false,
                    popToTopOnBlur: true,
                    tabBarIcon: ({ color, size }) => (
                        <MaterialCommunityIcons name="puzzle" size={size} color={color} />
                    )
                }
            } />
            <SamenSterkTab.Screen name='KalenderScreen' component={KalenderScreen} options={
                {
                    title: "Kalender",
                    headerTitleAlign: 'center',
                    tabBarIcon: ({ color, size }) => (
                        <FontAwesome5 name="calendar-plus" size={size} color={color} />
                    )
                }
            } />
            <SamenSterkTab.Screen name='InstellingenScreen' component={SettingsDrawerNavigator} options={
                {
                    title: "Instellingen",
                    headerShown: false,
                    tabBarIcon: ({ color, size }) => (
                        <FontAwesome5 name="cog" size={size} color={color} />
                    )
                }
            } />
        </SamenSterkTab.Navigator>
    )
}

export default SamenSterkTabNavigator