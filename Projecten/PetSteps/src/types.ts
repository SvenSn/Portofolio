

export const PET_TYPES = ["Dog", "Cat", "Horse", "Snake"] as const;
export type PetType = typeof PET_TYPES[number];

export type PetStats = {
    damage:number;
    health:number;
    speed: number; 
}

export type Pet ={
    id: string; 
    type: PetType;
    name:string; 
    level: number;
    imageUrl: string;
    stepsCurrent: number; 
    stepsToNextLevel: number; 
    baseSteps: number; 
    growthRate: number; //1.2 per level gaan de staats omhoog en ook de aantal stappen die je nodig hebt
    stats: PetStats; 
}