import {configureStore} from "@reduxjs/toolkit"
import GoNoGoReducer from "../store/puzzelSlices/GoNoGoSlice";
import settingsReducer from "../store/puzzelSlices/SettingsSlice";
import stroopReducer from "../store/puzzelSlices/StroopSlice"
import exerciseReducer from '../store/oefeningenSlice';
import geplandeOefeningReducer from '../store/geplandeOefeningSlice'
import accountSettingsReducer from './accountsettings/settingsSlice'
import gebruikerReducer from './gebruiker/gebruikerSlice'


export const store = configureStore({
    reducer: {
        goNoGo: GoNoGoReducer,
        stroop: stroopReducer,
        settings: settingsReducer,
        exercises : exerciseReducer,
        geplandeOefeningen: geplandeOefeningReducer,
        accountSettings: accountSettingsReducer,
        gebruiker: gebruikerReducer
    }
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;