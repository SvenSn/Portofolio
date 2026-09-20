import { PetStats } from "../../types";

export const scalePetStats = (
  stats: PetStats,
  growthRate: number
): PetStats => {

  return {
    //Damage wordt sterker
    damage: Math.floor(stats.damage * growthRate),

    //Health wordt hoger (meer HP)
    health: Math.floor(stats.health * growthRate),

    //Speed wordt sneller
    speed: Math.floor(stats.speed * growthRate),
  };
};
