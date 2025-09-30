using FitnessProject.Domein.DTOs;
using FitnessProject.Domein.Models;

namespace FitnessProject.Domein.Factories;

internal class KlantToKlantDTOFactory
{
    public static KlantDTO ConvertToKlantDTO(Klant klant)
    {

        KlantDTO klantDTO = new KlantDTO(klant.KlantNr);

        return klantDTO;
    }
}
