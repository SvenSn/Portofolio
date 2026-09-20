import { View, ViewProps } from "react-native";
import { twMerge } from "tailwind-merge";

const CardView = ({ children, className }: ViewProps) => {
    return (
        <View className={twMerge("bg-zinc-200 dark:bg-slate-800 rounded-2xl p-5", className)}>
            {children}
        </View>
    );
};

export default CardView;