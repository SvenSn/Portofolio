import React from 'react'
import { AccessibilityProps, View } from 'react-native'
import BasicText from '../components/BasicLayoutComponents/BasicText'

type InfoRijProps = {
    emoji: string
    titel: string
    value: number | string
} & AccessibilityProps

const InfoRij = ({ emoji, titel, value }: InfoRijProps) => (
    <View className="flex-row items-center justify-between py-3 border-b border-slate-200 dark:border-slate-700">

        <View className="flex-row items-center gap-3">
            <BasicText className="text-lg">
                {emoji}
            </BasicText>

            <BasicText
                variant="label"
                className="text-base"
            >
                {titel}
            </BasicText>
        </View>

        <BasicText
            className="text-lg font-semibold text-slate-900 dark:text-slate-50"
        >
            {value}
        </BasicText>

    </View>
)

export default InfoRij