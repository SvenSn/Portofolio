import {
    DarkTheme as NavigationDarkTheme,
    DefaultTheme as NavigationDefaultTheme,
} from '@react-navigation/native';

export const lightTheme = {
    ...NavigationDefaultTheme,
    colors: {
        ...NavigationDefaultTheme.colors,
        background: '#fafafa', // neutral-50
        card: '#ffffff',       // white
        border: '#e5e7eb',     // neutral-200
        text: '#171717',       // neutral-900
        primary: '#16a34a',
    },
} as const;

export const darkTheme = {
    ...NavigationDarkTheme,
    colors: {
        ...NavigationDarkTheme.colors,
        background: '#0a0a0a', // neutral-950
        card: '#171717',       // neutral-900
        border: '#262626',     // neutral-800
        text: '#f5f5f5',       // neutral-100
        primary: '#22c55e',
    },
} as const;