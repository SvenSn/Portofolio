using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories;

internal static class AutoDTOtoAutoFactory
{
    public static Auto ConvertAutoDTOtoAuto(AutoDTO autoDTO)
    
    {
        return new Auto(
            autoDTO.Nummerplaat,
            autoDTO.Model,
            autoDTO.Zitplaatsen, 
            (Auto.EMotorType)Enum.Parse(typeof(Auto.EMotorType),autoDTO.MotorType));
    }
}
