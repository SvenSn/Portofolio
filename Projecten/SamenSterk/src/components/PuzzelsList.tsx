import React from 'react';
import { FlatList, TouchableOpacity, View } from 'react-native';
import { PUZZLES } from '../data/puzzelData';
import { PuzzleType } from '../types/shared';
import BasicView from '../components/BasicLayoutComponents/BasicView';
import CardView from '../components/BasicLayoutComponents/CardView';
import BasicText from '../components/BasicLayoutComponents/BasicText';

interface Props {
    onSelectPuzzle: (puzzle: PuzzleType) => void;
}

const PuzzelsList = ({ onSelectPuzzle }: Props) => {
    return (
        <BasicView className="flex-1">
            <FlatList
                data={PUZZLES}
                keyExtractor={(item) => item.type}
                contentContainerClassName="p-4"
                renderItem={({ item }) => (
                    <TouchableOpacity
                        className="mb-3"
                        activeOpacity={0.8}
                        onPress={() => onSelectPuzzle(item.type)}
                    >
                        <CardView className="flex-row gap-4 items-center">

                            <BasicText className="text-3xl" accessibilityLabel={item.emoji}>
                                {item.emoji}
                            </BasicText>

                            <View className="flex-1">
                                <BasicText variant="body" className="font-bold text-lg" accessibilityLabel={item.label}>
                                    {item.label}
                                </BasicText>

                                <BasicText variant="label" className="mt-1" accessibilityLabel={item.shortDescription}>
                                    {item.shortDescription}
                                </BasicText>
                            </View>

                        </CardView>
                    </TouchableOpacity>
                )}
            />
        </BasicView>
    );
};

export default PuzzelsList;