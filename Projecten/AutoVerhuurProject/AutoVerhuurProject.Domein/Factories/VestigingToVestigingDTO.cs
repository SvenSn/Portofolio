using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories;

internal static class VestigingToVestigingDTO
{
    public static VestigingDTO ConvertVestigingToVestigingDTO(Vestiging vestiging)
    {
        return new VestigingDTO
            (vestiging.LuchthavenVestiging,
            vestiging.StraatVestiging,
            vestiging.PostcodeVestiging,
            vestiging.PlaatsVestiging,
            vestiging.LandVestiging);
    }
}
