import React from 'react'
import { View, ViewProps } from 'react-native'
import { twMerge } from 'tailwind-merge'



const Card = ({ children, className, ...props }: ViewProps) => {
    return (
        <View
            className={twMerge(
                'bg-white dark:bg-neutral-900 rounded-2xl p-4 border border-neutral-200 dark:border-neutral-800',
                className
            )}
            {...props}
        >
            {children}
        </View>
    )
}

export default Card