import {Pet, PetStats} from '../../types'
import {scalePetStats} from './scalePetStats'

export const applyStepsToPet = (
  pet: Pet,
  addedSteps: number
): Pet => {
  let stepsCurrent = pet.stepsCurrent + addedSteps;
  let level = pet.level;
  let stepsToNextLevel = pet.stepsToNextLevel;
  let stats: PetStats = { ...pet.stats };

  while (stepsCurrent >= stepsToNextLevel) {
    stepsCurrent -= stepsToNextLevel;
    level += 1;

    stepsToNextLevel = Math.floor(
      stepsToNextLevel * pet.growthRate
    );

    stats = scalePetStats(stats,pet.growthRate);
  }

  return {
    ...pet,
    level,
    stepsCurrent,
    stepsToNextLevel,
    stats,
  };
};
