using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;
using static AutoVerhuurProject.Domein.Models.Auto;
using System.Reflection;

namespace AutoVerhuurProject.Domein.Factories;

internal static class AutoToAutoDTOFactory
{
    public static AutoDTO ConvertAutoInAutoDTO(Auto auto)
    {
        return new AutoDTO
            (auto.Nummerplaat, 
            auto.Model,
            auto.Zitplaatsen,
            auto.MotorType.ToString());
       
    }
}
