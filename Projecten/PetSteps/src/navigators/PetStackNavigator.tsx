import React from 'react'
import { createStackNavigator } from '@react-navigation/stack'
import { PetStackParamsList } from './types'
import PetsScreen from '../screens/PetsScreen';
import CreatePetScreen from '../screens/CreatePetScreen';
import PetDetailScreen from '../screens/PetDetailScreen';
import { useColorScheme } from 'nativewind';


const PetStack = createStackNavigator<PetStackParamsList>();

const PetStackNavigator = () => {
    const { colorScheme } = useColorScheme();
    const isDark = colorScheme === 'dark';

    return (
        <PetStack.Navigator>
            <PetStack.Group
                screenOptions={{
                    headerTitleAlign: 'center'
                }}
            >
                <PetStack.Screen name='petList' component={PetsScreen} options={{ title: "Pets" }} />
                <PetStack.Screen name='addPets' component={CreatePetScreen} options={{ title: 'Create Pet' }} />
                <PetStack.Screen name='petDetails' component={PetDetailScreen} options={{ title: 'Pet Details' }} />
            </PetStack.Group>
        </PetStack.Navigator>
    )
}

export default PetStackNavigator