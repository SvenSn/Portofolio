using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Factories;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Models;

namespace CadeaubonProject.Domein.Managers
{
    public class BestellingManager (IBestellingRepository bestellingRepository): IBestellingManager
    {
        // voor de gebruiker dus alleen lees repos meekrijgen ..

        private IBestellingRepository _bestellingRepo = bestellingRepository is null ?
        throw new ArgumentNullException("Repository mag niet leeg zijn.") : bestellingRepository;


        

        public BestellingDTO? GeefBestelling(Guid id)
        {
            return _bestellingRepo.GetById(id);
        }

        public List<BestellingDTO> GeefBestellingen()
        {
            return _bestellingRepo.GetAll();
        }

        public IEnumerable<BestellingDTO?> GeefBestellingBijKlantId(Guid klantID)
        {
            return _bestellingRepo.GetByKlantId(klantID);
        }

        public void VoegBestellingToe(Guid bestellingId, string beschrijving, KlantDTO klantDTO, CadeaubonDTO cadeaubonDTO,string stripeID)
        {
            //klantdto naar klant maken voor bestelling met bestaande factories
            Klant klant = KlantDTOToKlantFactory.ConvertKlantDTOToKlant(klantDTO);

            //cadeaubondto naar cadeaubon voor bestelling met bestaande factories
            Cadeaubon cadeaubon = CadeaubonDTOToCadeaubonFactory.ConvertCadeaubonDTOToCadeaubon(cadeaubonDTO);

            //bestelling aanmaken door 3 lagen model
            Bestelling bestelling =  BestellingFactory.CreateNewBestelling(bestellingId, klant, beschrijving, cadeaubon);

            //bestelling omzetten naar dto

            BestellingDTO bestellingDTO = BestellingToBestellingDTOFactory.ConvertBestellingToBestellingDTO(bestelling);


            _bestellingRepo.Add(bestellingDTO,stripeID);
        }

        public void VerwijderBestelling(Guid bestellingId)
        {
            _bestellingRepo.Delete(bestellingId);
        }

        public void VoegTransactieToe(string stripeID,decimal prijsBetaald,string beschrijving)
        {
            _bestellingRepo.AddTransaction(stripeID, prijsBetaald, beschrijving);
        }


        public string GeefStripeId(Guid id)
        {
           return _bestellingRepo.GetStripeId(id);
        }
    }
}
