import React from 'react'
import { View, ViewProps } from 'react-native'
import { twMerge } from 'tailwind-merge'

type BasicViewProps = ViewProps & {
    className?: string
}

const BasicView = ({ children, className, ...props }: BasicViewProps) => {
    return (
        <View
            className={twMerge('flex-1 bg-white dark:bg-neutral-900', className)}
            {...props}
        >
            {children}
        </View>
    )
}

export default BasicView