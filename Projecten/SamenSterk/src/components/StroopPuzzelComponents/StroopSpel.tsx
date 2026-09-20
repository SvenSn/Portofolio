import React, { useCallback } from 'react'
import { useStroop } from '../../../src/hooks/useStroop'
import StroopTrialScherm from './StroopTrialScherm'
import StroopResultaat from './StroopResultaat'
import { StackNavigationProp } from '@react-navigation/stack'
import { PuzzelStackNavigatorParamsList } from '../../navigators/types'
import { useFocusEffect, useNavigation } from '@react-navigation/native'
import { useAppDispatch } from '../../hooks/ReduxHooks'
import { stopStroopPuzzle } from '../../store/puzzelSlices/StroopSlice'
import BasicView from '../../components/BasicLayoutComponents/BasicView'

type NavigateProp = StackNavigationProp<PuzzelStackNavigatorParamsList>

const StroopSpel = () => {

    const dispatch = useAppDispatch()
    const navigation = useNavigation<NavigateProp>()

    const {
        status,
        currentStimulus,
        score,
        trialIndex,
        totalTrials,
        start,
        submitAnswer,
    } = useStroop()

    useFocusEffect(
        useCallback(() => {

            start()

            return () => {
                dispatch(stopStroopPuzzle())
            }

        }, [dispatch])
    )

    if (status === 'finished' && score) {
        return (
            <BasicView className="flex-1">
                <StroopResultaat
                    score={score}
                    onRetry={start}
                />
            </BasicView>
        )
    }

    return (
        <BasicView className="flex-1">
            <StroopTrialScherm
                currentStimulus={currentStimulus}
                trialIndex={trialIndex}
                totalTrials={totalTrials}
                onAnswer={submitAnswer}
            />
        </BasicView>
    )
}

export default StroopSpel