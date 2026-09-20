import React from 'react'
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs'
import { PetStepsTabParamsList } from './types';
import Mapscreen from '../screens/Mapscreen';
import CameraScreen from '../screens/CameraScreen';
import FontAwesome5 from '@expo/vector-icons/FontAwesome5';
import MaterialIcons from '@expo/vector-icons/MaterialIcons';
import PetStackNavigator from './PetStackNavigator';
import InstellingenDrawerNavigator from './InstellingenDrawerNavigator';

const PetStepsTab = createBottomTabNavigator<PetStepsTabParamsList>();

const PetStepsTabNavigator = () => {

    return (
        <PetStepsTab.Navigator
            screenOptions={{
                headerTitleAlign: "center",
            }}
        >
            <PetStepsTab.Group>
                <PetStepsTab.Screen name='Pets' component={PetStackNavigator} options={{
                    title: "Pets",
                    headerShown: false,
                    tabBarIcon: ({ color, size }) => (<FontAwesome5 name="cat" size={size} color={color} />)
                }} />
                <PetStepsTab.Screen name='Camera' component={CameraScreen} options={{
                    title: "Camera",
                    tabBarIcon: ({ color, size }) => (<FontAwesome5 name="camera" size={size} color={color} />)
                }} />
                <PetStepsTab.Screen name='Map' component={Mapscreen} options={{
                    tabBarIcon: ({ color, size }) => (<FontAwesome5 name="map-marked-alt" size={size} color={color} />)
                }} />
                <PetStepsTab.Screen name='Instellingen' component={InstellingenDrawerNavigator} options={{
                    title: "Settings",
                    headerShown: false,
                    tabBarIcon: ({ color, size }) => (<MaterialIcons name="settings" size={size} color={color} />)
                }} />

            </PetStepsTab.Group>
        </PetStepsTab.Navigator>
    );

}

export default PetStepsTabNavigator