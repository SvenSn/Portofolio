import React, { forwardRef } from 'react'
import { TextInput, TextInputProps } from 'react-native'
import { twMerge } from 'tailwind-merge'
import BasicText from './BasicText'
import BasicView from './BasicView'

type BasicTextInputProps = TextInputProps & {
    label?: string
    error?: string
    className?: string
}

const BasicTextInput = forwardRef<TextInput, BasicTextInputProps>(
    ({ label, error, className, ...props }, ref) => {
        return (
            <BasicView className="flex-none gap-1">
                {label && (
                    <BasicText variant="label">{label}</BasicText>
                )}
                <TextInput
                    ref={ref}
                    className={twMerge(
                        'w-full rounded-2xl bg-white dark:bg-neutral-900',
                        'border-2 border-gray-700 dark:border-neutral-700',
                        'px-5 py-4 text-base text-zinc-900 dark:text-neutral-100',
                        error && 'border-red-500 dark:border-red-400',
                        className
                    )}
                    placeholderTextColor="#A1A1AA"
                    autoCapitalize="none"
                    autoCorrect={false}
                    {...props}
                />
                {error && (
                    <BasicText variant="caption" className="text-red-500 dark:text-red-400">
                        {error}
                    </BasicText>
                )}
            </BasicView>
        )
    }
)

export default BasicTextInput