import React, { ComponentType } from 'react';
import { StackScreenProps } from '@react-navigation/stack';
import { useSelector } from 'react-redux';

import { PuzzelStackNavigatorParamsList } from '../navigators/types';
import { RootState } from '../store/store';

import GoNoGoSpel from '../components/GoNoGopuzzelComponents/GoNoGoSpel';
import StroopSpel from '../components/StroopPuzzelComponents/StroopSpel';
import MemorySpel from '../components/MemorySpel';

import { PuzzleType } from '../store/puzzelSlices/SettingsSlice';
import BasicView from '../components/BasicLayoutComponents/BasicView';

const PUZZEL_COMPONENTEN: Record<PuzzleType, ComponentType<any>> = {
    goNoGo: GoNoGoSpel,
    stroop: StroopSpel,
    memory: MemorySpel
};

type Props = StackScreenProps<
    PuzzelStackNavigatorParamsList,
    'PuzzlePlay'
>;

const PuzzelPlayScreen = ({ route }: Props) => {
    const { puzzle } = route.params;

    const difficulty = useSelector(
        (state: RootState) => state.settings.difficulty[puzzle]
    );

    const PuzzelComponent = PUZZEL_COMPONENTEN[puzzle];

    return (
        <BasicView className="flex-1">
            <PuzzelComponent key={difficulty} difficulty={difficulty} />
        </BasicView>
    );
};

export default PuzzelPlayScreen;