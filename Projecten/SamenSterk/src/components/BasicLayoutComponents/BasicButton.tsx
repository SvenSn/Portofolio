import { AccessibilityProps, StyleSheet, Text, TouchableOpacity, View } from 'react-native'
import React from 'react'


type BasicButtonProps = {
    title: string;
    onPress: () => void;

} & AccessibilityProps

const BasicButton = ({ title, onPress }: BasicButtonProps) => {
    return (
        <TouchableOpacity onPress={onPress}
            className="bg-sky-600 px-5 py-3 rounded-2xl items-center justify-center shadow-sm active:bg-sky-700">
            <Text className='text-white text-xl font-semibold'>{title}</Text>
        </TouchableOpacity>
    )
}

export default BasicButton

const styles = StyleSheet.create({})