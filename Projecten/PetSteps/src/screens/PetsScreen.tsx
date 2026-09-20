import React from "react";
import { ActivityIndicator } from "react-native";
import { Ionicons } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import { useAppSelector } from "../hooks/ReduxHooks";
import { selectPetsArray, selectIsLoading } from "../store/pets/petSlice";
import { PetStackNavProps } from "../navigators/types";
import CreatePetScreen from "./CreatePetScreen";
import BasicView from "../components/BasicLayoutComponents/BasicView";
import PetList from "../components/PetList";
import BasicTouchableOpacity from "../components/BasicLayoutComponents/BasicTouchAbleOpacity";

const PetsScreen = () => {
    const pets = useAppSelector(selectPetsArray);
    const isLoading = useAppSelector(selectIsLoading);

    const navigation =
        useNavigation<PetStackNavProps<"petList">["navigation"]>();

    if (isLoading) {
        return (
            <BasicView className="flex-1 items-center justify-center">
                <ActivityIndicator size="large" />
            </BasicView>
        );
    }

    if (pets.length === 0) {
        return <CreatePetScreen />;
    }

    return (
        <BasicView className="flex-1 relative">
            <PetList
                onPressPet={(pet) =>
                    navigation.navigate("petDetails", { pet })
                }
            />

            <BasicTouchableOpacity
                onPress={() => navigation.navigate("addPets")}
                className="
                    absolute
                    bottom-6
                    right-6
                    w-16
                    h-16
                    rounded-full
                    items-center
                    justify-center
                    bg-green-500
                    dark:bg-green-600
                    shadow-lg
                "
            >
                <Ionicons name="add" size={28} color="white" />
            </BasicTouchableOpacity>
        </BasicView>
    );
};

export default PetsScreen;