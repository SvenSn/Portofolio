import { View, Text } from 'react-native'
import React from 'react'
import { createStackNavigator } from "@react-navigation/stack";
import { OefeningenStackNavigatorParamsList } from './types';
import App from '../../App';
import PuzzelsList from '../components/PuzzelsList';
import OefeningenList from '../components/OefeningenList';
import OefeningenScreen from '../screens/OefeningenScreen';
import OefeningenDetailsScreen from '../screens/OefeningenDetailsScreen';
import OefeningenInplannenScreen from '../screens/OefeningenInplannenScreen';
import AdminMaakOefeningScreen from '../screens/AdminMaakOefeningScreen';

const OefeningenStack = createStackNavigator<OefeningenStackNavigatorParamsList>();

const OefeningenStackNavigator = () => {
    return (
        <OefeningenStack.Navigator>
            <OefeningenStack.Screen name='OefeningenList' component={OefeningenScreen} options={{ title: "Oefeningen", headerTitleAlign: 'center' }} />
            <OefeningenStack.Screen name='OefeningDetails' component={OefeningenDetailsScreen} options={({ route }) => ({
                title: route.params.data.name ?? "Details",
            })} />
            <OefeningenStack.Screen name='OefeningenInplannen' component={OefeningenInplannenScreen} options={{ title: "Inplannen", headerTitleAlign: 'center' }} />
            <OefeningenStack.Screen name='AdminOefeningScreen' component={AdminMaakOefeningScreen} options={{ title: "Aanmaken oefeninng", headerTitleAlign: 'center' }} />
        </OefeningenStack.Navigator>
    )
}

export default OefeningenStackNavigator;