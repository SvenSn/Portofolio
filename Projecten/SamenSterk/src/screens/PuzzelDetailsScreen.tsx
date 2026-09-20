import React, { useEffect } from "react";
import { View, AccessibilityInfo } from "react-native";
import { useRoute, useNavigation } from "@react-navigation/native";
import { PuzzelStackNavProps } from "../navigators/types";

import PuzzelDetails from "../components/PuzzelDetails";
import BasicButton from "../components/BasicLayoutComponents/BasicButton";
import BasicView from "../components/BasicLayoutComponents/BasicView";

const PuzzleDetailScreen = () => {
    const {
        params: { puzzle },
    } = useRoute<PuzzelStackNavProps<"PuzzleDetail">["route"]>();

    const navigation =
        useNavigation<PuzzelStackNavProps<"PuzzleDetail">["navigation"]>();

    useEffect(() => {
        AccessibilityInfo.announceForAccessibility(
            `Puzzel details scherm. ${puzzle ?? "Puzzel geselecteerd"}`
        );
    }, []);

    const onBegin = () => {
        AccessibilityInfo.announceForAccessibility("Kies moeilijkheidsgraad");
        navigation.navigate("Moeilijkheid", { puzzle });
    };

    return (
        <BasicView className="flex-1">

            <PuzzelDetails
                puzzle={puzzle}
            />

            <View className="mt-auto px-6 pb-8">

                <BasicButton
                    onPress={onBegin}
                    title="Begin Puzzel"
                    accessibilityRole="button"
                    accessibilityLabel={`Start ${puzzle ?? "puzzel"}`}
                    accessibilityHint="Ga naar moeilijkheidsgraad kiezen"
                />

            </View>

        </BasicView>
    );
};

export default PuzzleDetailScreen;