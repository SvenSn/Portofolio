import { setDarkMode, setTextSize } from "../store/accountsettings/settingsSlice";
import { useAppDispatch, useAppSelector } from "./ReduxHooks";

export const useSettings = () => {
    const dispatch = useAppDispatch();
    const { darkMode, textSize } = useAppSelector((state) => state.accountSettings);

    const changeDarkMode = (value: boolean) => {
        dispatch(setDarkMode(value));
    };

    const changeTextSize = (size: 'normal' | 'large') => {
        dispatch(setTextSize(size));
    };

    return {
        darkMode,
        textSize,
        setDarkMode: changeDarkMode,
        setTextSize: changeTextSize,
    };
};
``