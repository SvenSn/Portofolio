import React from 'react';
import { View } from 'react-native';
import { useNavigation } from '@react-navigation/native';

import PuzzelsList from '../components/PuzzelsList';
import { PuzzelStackNavProps } from '../navigators/types';
import { PuzzleType } from '../types/shared';
import BasicView from '../components/BasicLayoutComponents/BasicView';

const PuzzelScreen = () => {
    const navigation =
        useNavigation<PuzzelStackNavProps<'PuzzelsList'>['navigation']>();

    const handleSelectPuzzle = (puzzle: PuzzleType) => {
        navigation.navigate('PuzzleDetail', { puzzle });
    };

    return (
        <BasicView className="flex-1">
            <PuzzelsList onSelectPuzzle={handleSelectPuzzle} />
        </BasicView>
    );
};

export default PuzzelScreen;