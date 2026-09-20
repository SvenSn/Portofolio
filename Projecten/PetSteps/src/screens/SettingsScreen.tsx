import { useAppSelector, useAppDispatch } from '../hooks/ReduxHooks';
import { toggleColorScheme, selectIsDark } from '../store/settings/settingsSlice';
import { Switch, View } from "react-native";
import BasicView from "../components/BasicLayoutComponents/BasicView";
import BasicText from "../components/BasicLayoutComponents/BasicText";
import React from 'react';

const SettingsScreen = () => {
    const dispatch = useAppDispatch();
    const isDark = useAppSelector(selectIsDark);

    const handleToggle = () => {
        dispatch(toggleColorScheme());
    };

    return (
        <BasicView className="flex-1 px-6 pt-8 gap-6">
            <BasicView className="flex-none rounded-2xl border border-neutral-200 dark:border-neutral-800 px-4 py-3">
                <View className="flex-row items-center justify-between">
                    <View>
                        <BasicText variant="heading">Dark mode</BasicText>
                        <BasicText variant="caption">{isDark ? "On" : "Off"}</BasicText>
                    </View>
                    <Switch value={isDark} onValueChange={handleToggle} />
                </View>
            </BasicView>
        </BasicView>
    );
};

export default SettingsScreen;