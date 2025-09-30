using FitnessProject.Domein.DTOs;
using FitnessProject.Domein.Models;

namespace FitnessProject.Domein.Factories;

internal class LooptrainingToLoopTrainingDTOFactory
{
    public static LoopTrainingDTO  ConvertLoopTrainingToLoopTrainingDTO(LoopTraining loopTraining)
    {
        LoopTrainingDTO loopTrainingDTO = new LoopTrainingDTO
            (loopTraining.SessieNr,
            loopTraining.StartDatumSessie,
            loopTraining.TotaleTrainingsDuurSessieMinuten,
            loopTraining.GemiddeldeSnelheidLoopTraining
            );

        return loopTrainingDTO;
    }
}
