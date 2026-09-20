import AsyncStorage from '@react-native-async-storage/async-storage';

const KEY = 'app_settings';

export const saveSettings = async (settings: any) => {
    await AsyncStorage.setItem(KEY, JSON.stringify(settings));
};

export const loadSettings = async () => {
    const data = await AsyncStorage.getItem(KEY);
    return data ? JSON.parse(data) : null;
};