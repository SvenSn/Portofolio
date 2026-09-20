import React from 'react'
import { Text, TextProps } from 'react-native'
import { twMerge } from 'tailwind-merge'

type TextVariant = 'body' | 'secondary' | 'heading' | 'label' | 'caption'

const variantStyles: Record<TextVariant, string> = {
    body: 'text-base text-neutral-800 dark:text-neutral-100',
    secondary: 'text-base text-neutral-500 dark:text-neutral-400',
    heading: 'text-2xl font-bold text-neutral-900 dark:text-neutral-50',
    label: 'text-sm font-medium text-neutral-700 dark:text-neutral-300',
    caption: 'text-xs text-neutral-400 dark:text-neutral-500',
}
type BasicTextProps = TextProps & {
    className?: string
    variant?: TextVariant
}

const BasicText = ({ children, className, variant = 'body', ...props }: BasicTextProps) => {
    return (
        <Text
            className={twMerge(variantStyles[variant], className)}
            {...props}
        >
            {children}
        </Text>
    )
}

export default BasicText;