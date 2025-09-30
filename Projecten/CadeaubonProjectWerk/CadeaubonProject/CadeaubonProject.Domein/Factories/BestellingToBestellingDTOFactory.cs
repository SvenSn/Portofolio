using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Models;

namespace CadeaubonProject.Domein.Factories;

internal class BestellingToBestellingDTOFactory
{
    public static BestellingDTO ConvertBestellingToBestellingDTO(Bestelling bestelling)
    {
        return new BestellingDTO(
            bestelling.AankoopId,
            bestelling.Beschrijving,
            KlantToKlantDTOFactory.ConvertKlantToKlantDTO(bestelling.KlantBestelling),
            CadeaubonToCadeaubonDTOFactory.ConvertCadeaubonToCadeaubonDTO(bestelling.CadeaubonBestelling)
            );

    }
}
