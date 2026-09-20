import { DefaultTheme, DarkTheme, Theme } from '@react-navigation/native';

export const MyLightTheme: Theme = {
    ...DefaultTheme,
    dark: false,
    colors: {
        ...DefaultTheme.colors,

        primary: '#2563eb',     // blue-600
        background: '#f8fafc',  // slate-50 (screen)
        card: '#ffffff',        // cards / header
        text: '#1e293b',        // slate-800
        border: '#e2e8f0',      // slate-200
        notification: '#ef4444',
    },
};

export const MyDarkTheme: Theme = {
    ...DarkTheme,
    dark: true,
    colors: {
        ...DarkTheme.colors,

        primary: '#60a5fa',     // blue-400 (lichter voor dark)
        background: '#0f172a',  // slate-900 (screen)
        card: '#1e293b',        // slate-800 (cards/header)
        text: '#f8fafc',        // slate-50
        border: '#334155',      // slate-700
        notification: '#ef4444',
    },
};
``