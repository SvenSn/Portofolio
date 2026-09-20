import React, { useEffect } from 'react'
import { View, Text, FlatList, ActivityIndicator } from 'react-native'
import { useNavigation } from '@react-navigation/native'
import { useAppDispatch, useAppSelector } from '../hooks/ReduxHooks'
import { useOefeningenListener } from '../hooks/useOefeningenListener'
import { selectFilteredExercises, setError, setExercises, setLoading } from '../store/oefeningenSlice'
import OefeningItem from './OefeningItem'
import { onSnapshot, collection } from 'firebase/firestore'
import { db } from '../firebase'
import { Exercise } from '../types/shared'
import { OefeningenStackNavigatorParamsList, OefeningenStackNavProps } from '../navigators/types'


const OefeningList = () => {
    useOefeningenListener();
    const navigation = useNavigation();
    const oefeningen = useAppSelector(selectFilteredExercises);
    const status = useAppSelector(state => state.exercises.status);



    if (status === 'loading') {
        return (
            <View className='flex-1 justify-center items-center'>
                <ActivityIndicator size='large' color='#3b82f6' />
            </View>
        )
    }

    if (status === 'error') {
        return (
            <View className='flex-1 justify-center items-center'>
                <Text className='text-red-500 text-base'>Iets ging fout</Text>
            </View>
        )
    }

    return (
        <FlatList
            data={oefeningen}
            keyExtractor={item => item.id}
            contentContainerStyle={{ padding: 16, gap: 12 }}
            showsVerticalScrollIndicator={false}
            renderItem={({ item }) => (
                <OefeningItem
                    oefening={item}
                    onPress={() => navigation.navigate('OefeningDetails', { data: item })}
                />
            )}
        />
    )
}

export default OefeningList