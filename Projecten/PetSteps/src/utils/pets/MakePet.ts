import { Pet, PetType } from "../../types";
import { DEFAULT_PET_CONFIG } from "../../config/pets/petConfig";


const config = DEFAULT_PET_CONFIG;

export const maakHuisdier = (
  id: string,
  name: string,
  type: PetType,
  imageUrl: string
): Pet => {

  return {
    id,
    name,
    type,
    imageUrl,

    //gameplay config (voor iedereen hetzelfde)
    baseSteps: config.baseSteps,
    growthRate: config.growthRate,
    stats: config.baseStats,

    // startwaarden
    level: 1,
    stepsCurrent: 0,
    stepsToNextLevel: config.baseSteps,
  };
};