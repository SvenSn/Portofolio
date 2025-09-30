using FitnessProject.Domein.DTOs;
using FitnessProject.Domein.Models;

namespace FitnessProject.Domein.Factories
{
    internal class LoopIntervalToLoopIntervalDTOFactory
    {
        public static LoopIntervalDTO ConvertLoopIntervalToLoopIntervalDTO(LoopInterval loopInterval)
        {
            LoopIntervalDTO loopintervalDTO = new LoopIntervalDTO
                (loopInterval.TijdsDuurIntervalSeconden,
                loopInterval.GemiddeldeSnelheidInterval,
                loopInterval.IntervalNr);


            return loopintervalDTO;
        }
    }
}
