import 'react-native-gesture-handler';
import React, { useEffect, useState } from 'react';
import './../../global.css';
import { ActivityIndicator, View } from 'react-native';
import { SafeAreaProvider } from 'react-native-safe-area-context';
import { Provider as ReduxProvider } from "react-redux";
import { store, persistor } from "../store/store";
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { auth } from '../config/firebase';
import { onAuthStateChanged, User } from 'firebase/auth';
import AppContent from './AppContent';
import { PersistGate } from 'redux-persist/integration/react';
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useColorScheme } from "nativewind";
import { useAppSelector } from "../hooks/ReduxHooks";
import { selectIsDark } from "../store/settings/settingsSlice";

const queryClient = new QueryClient();


const Root = () => {
    const [user, setUser] = useState<User | null>(null);
    const [isAuthLoading, setIsAuthLoading] = useState(true);

    useEffect(() => {
        const unsubscribe = onAuthStateChanged(auth, (firebaseUser) => {
            setUser(firebaseUser);
            setIsAuthLoading(false);
        });
        return unsubscribe;
    }, []);

    if (isAuthLoading) {
        return (
            <View className="flex-1 items-center justify-center">
                <ActivityIndicator size="large" />
            </View>
        );
    }

    return (
        <SafeAreaProvider>
            <ReduxProvider store={store}>
                <PersistGate loading={<ActivityIndicator />} persistor={persistor}>
                    <QueryClientProvider client={queryClient}>
                        <AppContent user={user} />
                    </QueryClientProvider>
                </PersistGate>
            </ReduxProvider>
        </SafeAreaProvider>
    );
};

export default Root;