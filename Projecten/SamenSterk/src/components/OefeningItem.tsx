import React from 'react'
import { TouchableOpacity, View } from 'react-native'
import { Exercise } from '../types/shared'
import CardView from '../components/BasicLayoutComponents/CardView'
import BasicText from '../components/BasicLayoutComponents/BasicText'

type OefeningItemProps = {
    oefening: Exercise
    onPress: () => void
}

const OefeningItem = ({ oefening, onPress }: OefeningItemProps) => {
    return (
        <TouchableOpacity
            onPress={onPress}
            activeOpacity={0.7}
            className="mb-3"
        >
            <CardView className="p-4">

                <View className="flex-col">
                    <BasicText variant="body" className="font-semibold text-lg" accessibilityLabel={oefening.name}>
                        {oefening.name}
                    </BasicText>

                    <BasicText variant="label" className="mt-1" accessibilityLabel={oefening.KorteBeschrijving}>
                        {oefening.KorteBeschrijving}
                    </BasicText>
                </View>

            </CardView>
        </TouchableOpacity>
    )
}

export default OefeningItem
