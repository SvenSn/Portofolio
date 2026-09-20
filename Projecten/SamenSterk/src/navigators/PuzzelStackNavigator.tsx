import React from 'react'
import { createStackNavigator } from '@react-navigation/stack'
import { PuzzelStackNavigatorParamsList } from './types'

import PuzzelScreen from '../screens/PuzzelScreen'
import PuzzleDetailScreen from '../screens/PuzzelDetailsScreen'
import MoeilijkheidsGraadScreen from '../screens/MoeilijkheidsgraadScreen'
import PuzzelPlayScreen from '../screens/PuzzlePlayScreen'

const PuzzelStack = createStackNavigator<PuzzelStackNavigatorParamsList>()

const PuzzelStackNavigator = () => {
    return (
        <PuzzelStack.Navigator>
            <PuzzelStack.Screen
                name="PuzzelsList"
                component={PuzzelScreen}
                options={{ title: 'Puzzels', headerTitleAlign: 'center' }}
            />
            <PuzzelStack.Screen
                name="PuzzleDetail"
                component={PuzzleDetailScreen}
                options={{ title: 'Details', headerTitleAlign: 'center' }}
            />
            <PuzzelStack.Screen
                name="Moeilijkheid"
                component={MoeilijkheidsGraadScreen}
                options={{ title: 'Moeilijkheid Instellen' }}
            />
            <PuzzelStack.Screen name='PuzzlePlay' component={PuzzelPlayScreen} />
        </PuzzelStack.Navigator>
    )
}

export default PuzzelStackNavigator