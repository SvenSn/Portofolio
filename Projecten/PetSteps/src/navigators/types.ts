import {BottomTabScreenProps} from '@react-navigation/bottom-tabs'
import {type StackScreenProps } from '@react-navigation/stack'
import {DrawerScreenProps } from '@react-navigation/drawer'
import { Pet } from '../types';


export type PetStepsTabParamsList = {
    Pets: undefined;
    Camera: undefined;
    Map: undefined;
    Instellingen: undefined;
}

export type InstellingenDrawersParamsList = { 
    Account: undefined;
    About: undefined;
    StepStats: undefined;
    Settings: undefined;
}

export type PetStackParamsList = { 
    petList: undefined; 
    petDetails: {pet : Pet};
    addPets: undefined;
}

export type AuthStackParamslist = {
    login: undefined;
    register: undefined;
}

export type PetStepsTabNavProps<T extends keyof PetStepsTabParamsList> = BottomTabScreenProps<PetStepsTabParamsList,T>
export type AuthStackNavProps<T extends keyof AuthStackParamslist> = StackScreenProps<AuthStackParamslist,T>
export type PetStackNavProps<T extends keyof PetStackParamsList> = StackScreenProps<PetStackParamsList,T>
export type InstellingenDrawNavProps<T extends keyof InstellingenDrawersParamsList> = DrawerScreenProps<InstellingenDrawersParamsList,T>

declare global {
    namespace ReactNavigation {
        interface RootParamList extends PetStepsTabParamsList, AuthStackParamslist,PetStackParamsList,InstellingenDrawersParamsList {}
    }
}