import React from 'react'
import { View, ViewProps } from 'react-native'
import { twMerge } from 'tailwind-merge'

const SectieContainer = ({ children, className }: ViewProps) => {
    return (
        <View
            className={twMerge(
                "w-full rounded-2xl p-5 bg-white dark:bg-slate-800 border border-slate-200 dark:border-slate-700",
                className
            )}
        >
            {children}
        </View>
    )
}

export default SectieContainer