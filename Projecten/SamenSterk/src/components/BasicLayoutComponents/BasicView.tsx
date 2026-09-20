import { View, Text, ViewProps } from 'react-native'
import React from 'react'
import { twMerge } from 'tailwind-merge'

const BasicView = ({ children, className }: ViewProps) => {
    return (
        <View className={twMerge("bg-zinc-50 dark:bg-slate-900 rounded-2xl", className)} >
            {children}
        </View >
    )
}

export default BasicView