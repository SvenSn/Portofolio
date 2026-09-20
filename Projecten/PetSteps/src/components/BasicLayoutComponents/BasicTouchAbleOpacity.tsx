import React from 'react'
import { TouchableOpacity, TouchableOpacityProps } from 'react-native'
import { twMerge } from 'tailwind-merge'
import BasicText from './BasicText'

type TouchableVariant = 'primary' | 'secondary' | 'ghost' | 'destructive'

const buttonStyles: Record<TouchableVariant, string> = {
    primary: 'bg-neutral-900 dark:bg-neutral-100',
    secondary: 'bg-neutral-200 dark:bg-neutral-800 border border-neutral-300 dark:border-neutral-700',
    ghost: 'bg-transparent',
    destructive: 'bg-red-500 dark:bg-red-600',
}

const textStyles: Record<TouchableVariant, string> = {
    primary: 'text-white dark:text-neutral-900',
    secondary: 'text-neutral-800 dark:text-neutral-100',
    ghost: 'text-neutral-800 dark:text-neutral-100',
    destructive: 'text-white',
}

type BasicTouchableOpacityProps = TouchableOpacityProps & {
    variant?: TouchableVariant
    className?: string
}


const BasicTouchableOpacity = ({
    children,
    variant = 'primary',
    className,
    ...props
}: BasicTouchableOpacityProps) => {

    const isText = typeof children === 'string';

    return (
        <TouchableOpacity
            className={twMerge(
                'w-full rounded-2xl py-4 items-center active:opacity-70',
                buttonStyles[variant],
                className
            )}
            {...props}
        >
            {isText ? (
                <BasicText className={twMerge('text-base font-semibold', textStyles[variant])}>
                    {children}
                </BasicText>
            ) : (
                children
            )}
        </TouchableOpacity>
    );
};


export default BasicTouchableOpacity