import React from "react";
import { FlatList, Image } from "react-native";

import BasicView from "../components/BasicLayoutComponents/BasicView";
import BasicText from "../components/BasicLayoutComponents/BasicText";
import BasicTouchableOpacity from "../components/BasicLayoutComponents/BasicTouchAbleOpacity";
import Card from "../components/BasicLayoutComponents/Card";

import { Pet } from "../types";
import { useAppSelector } from "../hooks/ReduxHooks";
import { selectPetsSortedWithActiveFirst } from "../store/pets/petSlice";

type Props = {
    onPressPet: (pet: Pet) => void;
};

const PetList = ({ onPressPet }: Props) => {
    const sortedPets = useAppSelector(selectPetsSortedWithActiveFirst);
    const activePetId = useAppSelector((state) => state.pets.activePetId);

    const renderItem = ({ item }: { item: Pet }) => {
        const isActive = item.id === activePetId;

        const progress =
            item.stepsToNextLevel > 0
                ? Math.min(
                      100,
                      (item.stepsCurrent / item.stepsToNextLevel) * 100
                  )
                : 0;
        const progressRounded = Math.round(progress);

        return (
            <Card
                className={`mb-3 border ${
                    isActive
                        ? "border-green-500 dark:border-green-400"
                        : "border-neutral-200 dark:border-neutral-800"
                }`}
            >
                <BasicTouchableOpacity
                    variant="ghost"
                    onPress={() => onPressPet(item)}
                    className="flex-row items-center gap-3"
                >
                    <Image
                        source={{ uri: item.imageUrl }}
                        className="w-14 h-14 rounded-xl"
                    />

                    <BasicView className="flex-1 bg-transparent relative">
                        {isActive && (
                            <BasicView className="absolute right-0 top-0 px-2 py-1 rounded-full bg-green-500">
                                <BasicText className="text-white text-[10px] font-bold">
                                    ACTIVE
                                </BasicText>
                            </BasicView>
                        )}

                        <BasicText className="text-lg font-bold">
                            {item.name}
                        </BasicText>

                        <BasicText variant="secondary">
                            {item.type} • Level {item.level}
                        </BasicText>

                        <BasicView className="h-3 w-full mt-2 rounded-full border border-neutral-300 dark:border-neutral-700 bg-neutral-200 dark:bg-neutral-900 overflow-hidden">
                            <BasicView
                                className="h-full bg-green-500 dark:bg-green-400"
                                style={{ width: `${progress}%` }}
                            />
                        </BasicView>

                        <BasicView className="mt-1 flex-row items-center justify-between bg-transparent">
                            <BasicText variant="caption">
                                {item.stepsCurrent}/{item.stepsToNextLevel} steps
                            </BasicText>
                            <BasicText variant="caption" className="font-semibold">
                                {progressRounded}%
                            </BasicText>
                        </BasicView>
                    </BasicView>
                </BasicTouchableOpacity>
            </Card>
        );
    };

    return (
        <BasicView className="px-4 pt-4">
            <FlatList
                data={sortedPets}
                keyExtractor={(item) => item.id}
                renderItem={renderItem}
                showsVerticalScrollIndicator={false}
                contentContainerStyle={{ paddingBottom: 40 }}
                ListHeaderComponent={
                    <BasicView className="mb-5 bg-transparent">
                        <BasicText variant="heading">
                            Your Pets
                        </BasicText>
                    </BasicView>
                }
            />
        </BasicView>
    );
};

export default PetList;