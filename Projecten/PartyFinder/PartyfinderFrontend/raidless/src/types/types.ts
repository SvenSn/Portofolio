import type { ReactNode } from "react";

export interface ProtectedRouteProps {
    children: ReactNode;
    requiredRole?: string | string[];
}


export interface MemberRequestPayload {
    Username : string;
    IdentityServerId : string;
}

export interface PlayerRequestContract {
    email: string;
    userName: string;
    password: string;
}


export interface PreLobbyRequestContract {
  IdentityServerId : string;
  Boss : string; 
  TargetSize : number;
}
export interface PreLobbyResponseContract {
    id: string;
    boss: BossType;
    leaderId: string;
    inviteToken: string;
    createdAt: Date;
    targetSize: number;
    maxSize: number;
    members: MemberResponseContract[];
}

export interface MemberResponseContract {
  id: string;
  username: string;
  identityserverId: string;
  accountType : string;
  memberState: string;
}


export const BossType = {
    Bandos: "Bandos",
    Armadyl: "Armadyl",
    Saradomin: "Saradomin",
    Zamorak: "Zamorak",
    Nex: "Nex",
    Nightmare: "Nightmare",
    PhosaniNightmare: "PhosaniNightmare",
    ChambersOfXeric: "ChambersOfXeric",
    TheatreOfBlood: "TheatreOfBlood",
    TombsOfAmascut: "TombsOfAmascut",
    CorporealBeast: "CorporealBeast",
    Callisto: "Callisto",
    Venenatis: "Venenatis",
    Vetion: "Vetion",
    ChaosFanatic: "ChaosFanatic",
    Scorpia: "Scorpia",
    KingBlackDragon: "KingBlackDragon",
    Zalcano: "Zalcano",
    Wintertodt: "Wintertodt",
    Temperaross: "Temperaross",
    DagganothKings: "DagganothKings"
} as const;

export type BossType = typeof BossType[keyof typeof BossType];

export const BossTypeDisplayNames: Record<BossType, string> = {
    [BossType.Bandos]: "Bandos",
    [BossType.Armadyl]: "Armadyl",
    [BossType.Saradomin]: "Saradomin",
    [BossType.Zamorak]: "Zamorak",
    [BossType.Nex]: "Nex",
    [BossType.Nightmare]: "Nightmare",
    [BossType.PhosaniNightmare]: "Phosani Nightmare",
    [BossType.ChambersOfXeric]: "Chambers of Xeric",
    [BossType.TheatreOfBlood]: "Theatre of Blood",
    [BossType.TombsOfAmascut]: "Tombs of Amascut",
    [BossType.CorporealBeast]: "Corporeal Beast",
    [BossType.Callisto]: "Callisto",
    [BossType.Venenatis]: "Venenatis",
    [BossType.Vetion]: "Vetion",
    [BossType.ChaosFanatic]: "Chaos Fanatic",
    [BossType.Scorpia]: "Scorpia",
    [BossType.KingBlackDragon]: "King Black Dragon",
    [BossType.Zalcano]: "Zalcano",
    [BossType.Wintertodt]: "Wintertodt",
    [BossType.Temperaross]: "Temperaross",
    [BossType.DagganothKings]: "Dagganoth Kings"
};

export interface LobbyResponseContract {
    Id: string;
    Boss: string;
    IsActive: boolean;
    CreatedAt: string;
    FinishedAt: string | null;
    Members: MemberResponseContract[];
}


export interface Message {
    username: string;
    message: string;
    timestamp: string;
}

export interface ChatBoxProps {
    lobbyId: string;
    messages: Message[];
    onSend: (message: string) => Promise<void>;
}
export interface QueuePartyResponseContract {
    id: string;
    boss: string;
    targetSize: number;
    createdAt: string;
    members: MemberResponseContract[];
}

