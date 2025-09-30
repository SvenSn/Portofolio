using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories
{
    internal static class VestigingDTOToVestigingFactory
    {
        public static Vestiging ConvertVestigingDTOToVestiging (VestigingDTO vestigingDTO)
        {
            
            return new Vestiging
                (vestigingDTO.LuchthavenVestiging,
                vestigingDTO.StraatVestiging,
                vestigingDTO.PostcodeVestiging,
                vestigingDTO.PlaatsVestiging,
                vestigingDTO.LandVestiging);
        
        }
    }
}
