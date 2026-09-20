import React from "react";
import { TouchableOpacity, View } from "react-native";
import BasicText from "../components/BasicLayoutComponents/BasicText";
import CardView from "../components/BasicLayoutComponents/CardView";

type MoeilijkheidsgraadButtonProps = {
    emoji: string;
    label: string;
    omschrijving: string;
    actief: boolean;
    onPress: () => void;
};

const MoeilijkheidsgraadButton = ({
    emoji,
    label,
    omschrijving,
    actief,
    onPress,
}: MoeilijkheidsgraadButtonProps) => {
    return (
        <TouchableOpacity
            onPress={onPress}
            activeOpacity={0.7}
            accessibilityRole="button"
            accessibilityLabel={`${label}. ${omschrijving}`}
            accessibilityHint={
                actief
                    ? `${label} is geselecteerd`
                    : `Selecteer ${label} moeilijkheidsgraad`
            }
            accessibilityState={{ selected: actief }}
        >
            <CardView
                className={`
                    w-full flex-row items-center gap-4 px-5 py-5 rounded-2xl
                    ${actief
                        ? 'bg-sky-600 border-2 border-sky-700'
                        : 'bg-white dark:bg-slate-800 border border-slate-200 dark:border-slate-700'
                    }
                `}
            >

                {actief && (
                    <View
                        className="absolute left-0 top-0 bottom-0 w-1 bg-white rounded-l-2xl"
                        accessible={false}
                    />
                )}

                <BasicText
                    className="text-3xl"
                    accessibilityLabel={emoji}
                >
                    {emoji}
                </BasicText>

                <View className="flex-1">

                    <BasicText
                        className={`
                            text-xl font-bold
                            ${actief ? 'text-white' : ''}
                        `}
                        accessibilityLabel={label}
                    >
                        {label}
                    </BasicText>

                    <BasicText
                        variant="label"
                        className={`
                            mt-1
                            ${actief ? 'text-white/90' : ''}
                        `}
                        accessibilityLabel={omschrijving}
                    >
                        {omschrijving}
                    </BasicText>

                </View>

                <View
                    className={`
                        w-7 h-7 rounded-full items-center justify-center
                        ${actief
                            ? 'bg-white'
                            : 'border border-slate-300 dark:border-slate-600'
                        }
                    `}
                    accessibilityLabel={
                        actief ? "Geselecteerd" : "Niet geselecteerd"
                    }
                >
                    {actief && (
                        <View
                            className="w-3 h-3 rounded-full bg-sky-600"
                            accessible={false}
                        />
                    )}
                </View>

            </CardView>
        </TouchableOpacity>
    );
};

export default MoeilijkheidsgraadButton;