using FitnessProject.Domein.DTOs;
using FitnessProject.Domein.Models;

namespace FitnessProject.Domein.Factories;

internal class KlantDTOToKlantFactory
{
    public static Klant ConvertKlanDTOToKlant(KlantDTO klantDTO)
    {
        return new Klant
            (
            klantDTO.KlantNr
            );
    }
}
