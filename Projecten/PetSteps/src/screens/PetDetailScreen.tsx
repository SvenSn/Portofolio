import React from "react";
import { Image, ScrollView } from "react-native";
import { useSelector } from "react-redux";
import { RouteProp, useRoute } from "@react-navigation/native";
import BasicView from "../components/BasicLayoutComponents/BasicView";
import BasicText from "../components/BasicLayoutComponents/BasicText";
import Card from "../components/BasicLayoutComponents/Card";
import BasicTouchableOpacity from "../components/BasicLayoutComponents/BasicTouchAbleOpacity";
import { RootState } from "../store/store";
import { Pet } from "../types";
import { useSetActivePet } from "../hooks/useSetActivePet";
import { auth } from "../config/firebase";

type RouteParams = {
    petDetails: {
        pet: Pet;
    };
};

const PetDetailScreen = () => {
    const route = useRoute<RouteProp<RouteParams, "petDetails">>();
    const petId = route.params.pet.id;

    const user = auth.currentUser;

    const pet = useSelector((state: RootState) =>
        state.pets.pets.find(p => p.id === petId)
    );

    const activePetId = useSelector(
        (state: RootState) => state.pets.activePetId
    );

    const { setActivePet } = useSetActivePet();

    if (!pet) return null;

    const isActive = pet.id === activePetId;

    return (
        <ScrollView className='flex-1 bg-white dark:bg-neutral-900'>
            <BasicView className="px-5 pt-6">

                <Card className="items-center mb-5">

                    <Image
                        source={{ uri: pet.imageUrl }}
                        className="w-28 h-28 rounded-2xl mb-4"
                    />

                    <BasicView className="items-center mb-2">
                        <BasicText variant="heading" className="text-center">
                            {pet.name}
                        </BasicText>

                        {isActive && (
                            <BasicView className="mt-2 px-3 py-1 rounded-full bg-green-500 self-center">
                                <BasicText className="text-white text-[10px] font-bold">
                                    ACTIVE
                                </BasicText>
                            </BasicView>
                        )}
                    </BasicView>

                    <BasicText variant="secondary">
                        {pet.type} • Level {pet.level}
                    </BasicText>

                </Card>

                {!isActive && (
                    <BasicTouchableOpacity
                        className="mb-5"
                        onPress={() => {
                            if (!user?.uid) return;
                            setActivePet(user.uid, pet.id);
                        }}
                    >
                        Set as Active Pet
                    </BasicTouchableOpacity>
                )}

                <Card className="mb-5">
                    <BasicText variant="heading" className="mb-4">
                        Stats
                    </BasicText>

                    <BasicView className="space-y-3">

                        <BasicView className="flex-row justify-between">
                            <BasicText variant="label">Health</BasicText>
                            <BasicText variant="body">{pet.stats.health}</BasicText>
                        </BasicView>

                        <BasicView className="flex-row justify-between">
                            <BasicText variant="label">Damage</BasicText>
                            <BasicText variant="body">{pet.stats.damage}</BasicText>
                        </BasicView>

                        <BasicView className="flex-row justify-between">
                            <BasicText variant="label">Speed</BasicText>
                            <BasicText variant="body">{pet.stats.speed}</BasicText>
                        </BasicView>

                    </BasicView>
                </Card>

                <Card className="mb-10">
                    <BasicText variant="heading" className="mb-3">
                        Info
                    </BasicText>

                    <BasicView className="space-y-2">
                        <BasicText variant="secondary">
                            Growth Rate: {pet.growthRate}
                        </BasicText>

                        <BasicText variant="secondary">
                            Base Steps: {pet.baseSteps}
                        </BasicText>
                    </BasicView>
                </Card>

            </BasicView>
        </ScrollView>
    );
};

export default PetDetailScreen;