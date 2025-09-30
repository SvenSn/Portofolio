using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories;

internal static class KlantToKlantDTOFactory
{
    public static KlantDTO ConvertKlantToKlantDTO(Klant klant)
    {
        return new KlantDTO
            (klant.Voornaam,
            klant.Achternaam,
            klant.Email,
            klant.Straat,
            klant.Postcode,
            klant.Woonplaats,
            klant.Land);
    }
}
