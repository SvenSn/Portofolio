import { type StackScreenProps } from "@react-navigation/stack";
import { BottomTabScreenProps} from "@react-navigation/bottom-tabs"
import { PuzzleType ,Exercise} from "../types/shared";
import {DrawerScreenProps} from '@react-navigation/drawer'


export type OefeningenStackNavigatorParamsList = {
    OefeningenList : undefined;
    OefeningDetails: {
        data: Exercise;
    }
    OefeningenInplannen: {
        data : Exercise;
    }
    AdminOefeningScreen: undefined;
};

export type SettingsDrawerParamsList = { 
    about: undefined;
    account: undefined;
    toegangkelijkheid: undefined;
}

export type PuzzelStackNavigatorParamsList = {
  PuzzelsList: undefined;
  PuzzleDetail: { puzzle: PuzzleType };
  Moeilijkheid: { puzzle: PuzzleType };
  PuzzlePlay: { puzzle: PuzzleType };
}

export type AuthStackParamsList = {
    Login: undefined;
    Register: undefined;
}


export type AccountStackParamsList = {
    accountsettings: undefined;
    paswoordChange: undefined;
}

export type SamenSterkTabParamsList = { 
    PuzzelStack : undefined;
    OefeningenStack: undefined;
    KalenderScreen: undefined;
    InstellingenScreen: undefined;
}

export type SettingsDrawerNavProps<T extends keyof SettingsDrawerParamsList> = DrawerScreenProps<SettingsDrawerParamsList, T>
export type AuthStackNavProps<T extends keyof AuthStackParamsList> = StackScreenProps<AuthStackParamsList,T>
export type OefeningenStackNavProps<T extends keyof OefeningenStackNavigatorParamsList> = StackScreenProps<OefeningenStackNavigatorParamsList,T>
export type SamenSterkTabNavProps<T extends keyof SamenSterkTabParamsList> = BottomTabScreenProps<SamenSterkTabParamsList,T>
export type  PuzzelStackNavProps<T extends keyof PuzzelStackNavigatorParamsList> = StackScreenProps<PuzzelStackNavigatorParamsList,T>
export type AccountStackNavProps<T extends keyof AccountStackParamsList> = StackScreenProps<AccountStackParamsList,T>

declare global{
    namespace ReactNavigation{
        interface RootParamList extends OefeningenStackNavigatorParamsList,SamenSterkTabParamsList,PuzzelStackNavigatorParamsList,AuthStackParamsList,SettingsDrawerParamsList,AccountStackParamsList {}
    }
}