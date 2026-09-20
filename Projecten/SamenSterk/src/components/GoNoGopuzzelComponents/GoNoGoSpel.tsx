import React, { useCallback } from 'react'
import { useGoNoGo } from '../../../src/hooks/useNoGo'
import GoNoGoTrialScherm from './GoNoGoTrialScherm'
import GoNoGoResultaat from './GoNoGoResultaat'
import { useFocusEffect } from '@react-navigation/native'
import { useDispatch } from 'react-redux'
import { stopGoNoGoPuzzle } from '../../store/puzzelSlices/GoNoGoSlice'

const GoNoGoSpel = () => {

    const dispatch = useDispatch()

    const {
        status,
        currentStimulus,
        score,
        trialIndex,
        totalTrials,
        start,
        respond,
    } = useGoNoGo()

    useFocusEffect(
        useCallback(() => {
            start()

            return () => {
                dispatch(stopGoNoGoPuzzle())
            }
        }, [])
    )

    if (status === 'finished' && score) {
        return (
            <GoNoGoResultaat
                score={score}
                onOpnieuw={start}
            />
        )
    }

    return (
        <GoNoGoTrialScherm
            status={status}
            currentStimulus={currentStimulus}
            trialIndex={trialIndex}
            totalTrials={totalTrials}
            onRespond={respond}
        />
    )
}

export default GoNoGoSpel
