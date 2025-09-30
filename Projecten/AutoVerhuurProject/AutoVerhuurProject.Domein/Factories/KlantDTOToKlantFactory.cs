using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories
{
    internal static class KlantDTOToKlantFactory
    {
        public static Klant ConvertKlantDTOToKlant (KlantDTO klantDTO)
        {
            return new Klant
                (klantDTO.Voornaam,
                klantDTO.Achternaam,
                klantDTO.Email,
                klantDTO.Straat,
                klantDTO.Postcode,
                klantDTO.Woonplaats,
                klantDTO.Land);
        }
    }
}
