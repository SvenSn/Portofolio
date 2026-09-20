import { NavigationContainer } from "@react-navigation/native";
import { User } from "firebase/auth";
import React, { useEffect } from "react";
import { useColorScheme } from "nativewind";

import { useAppSelector } from "../hooks/ReduxHooks";
import { usePetsSync } from "../hooks/UsePetsSync";
import AuthStackNavigator from "../navigators/AuthStackNavigator";
import PetStepsTabNavigator from "../navigators/PetStepsTabNavigator";
import { PedometerProvider } from "../providers/PedometerProvider";
import { selectIsDark } from "../store/settings/settingsSlice";
import { darkTheme, lightTheme } from "../theme/NavigationTheme";

const AppContent = ({ user }: { user: User | null }) => {
    const { setColorScheme } = useColorScheme();
    const isDark = useAppSelector(selectIsDark);

    useEffect(() => {
        setColorScheme(isDark ? "dark" : "light");
    }, [isDark, setColorScheme]);

    const navigationTheme = isDark ? darkTheme : lightTheme;

    usePetsSync(user?.uid!);

    return (
        <NavigationContainer theme={navigationTheme}>
            {user ? (
                <PedometerProvider userId={user.uid}>
                    <PetStepsTabNavigator />
                </PedometerProvider>
            ) : (
                <AuthStackNavigator />
            )}
        </NavigationContainer>
    );
};

export default AppContent;