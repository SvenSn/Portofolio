using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Factories;
using AutoVerhuurProject.Domein.Interfaces;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein
{
    public class ReserveringManager(IReserveringRepositoryFull reserveringRepositoryFull)
    {
      
        private IReserveringRepositoryFull _reserveringRepositoryFull =
           reserveringRepositoryFull is null ?
           throw new ArgumentNullException("De reserveringrepository mag niet null zijn") :
           reserveringRepositoryFull;

        public IEnumerable<ReserveringDTO> GeefAlleReserveringen()
        {
            return _reserveringRepositoryFull.GetAllReserveringen();
        }
        

        public bool IsAutosBeschikBaar(string nummerplaat, DateTime startdatum, DateTime einddatum)
        {
            return reserveringRepositoryFull.IsAutoBeschikbaar(nummerplaat, startdatum, einddatum);
        }

        public void VoegReserveringToe(KlantDTO klantdto, VestigingDTO luchthaven, AutoDTO autodto,DateTime starthuurperiode,DateTime eindehuurperiode)
        {
            Klant klant = KlantDTOToKlantFactory.ConvertKlantDTOToKlant(klantdto);
            Vestiging vestiging = VestigingDTOToVestigingFactory.ConvertVestigingDTOToVestiging(luchthaven);
            Auto auto = AutoDTOtoAutoFactory.ConvertAutoDTOtoAuto(autodto);

            Console.WriteLine(klant.Voornaam);

            Reservering reservering = ReserveringFactory.CreateNewReseveringen(klant, vestiging, auto, starthuurperiode, eindehuurperiode);
    
            ReserveringDTO reserveringDTO = ReserveringToReserveringDTOFactory.ConvertReserveringToReserveringDTO(reservering);

            reserveringRepositoryFull.Add(reserveringDTO);
        }
    }
}
