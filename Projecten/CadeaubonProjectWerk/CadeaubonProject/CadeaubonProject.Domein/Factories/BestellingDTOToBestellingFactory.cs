using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Models;

namespace CadeaubonProject.Domein.Factories;


 internal class BestellingDTOToBestellingFactory
    {
        public Bestelling ConvertBestellingDTOToBestelling(BestellingDTO bestellingdto)
        {
            
            return new Bestelling
            (
                bestellingdto.AankoopId,
                KlantDTOToKlantFactory.ConvertKlantDTOToKlant(bestellingdto.klantDTO),
                bestellingdto.Beschrijving,
                CadeaubonDTOToCadeaubonFactory.ConvertCadeaubonDTOToCadeaubon(bestellingdto.cadeaubonDTO)
            );
        }
    }

