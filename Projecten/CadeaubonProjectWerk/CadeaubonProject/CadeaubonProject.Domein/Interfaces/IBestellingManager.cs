using CadeaubonProject.Domein.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Interfaces
{
    public interface IBestellingManager
    {
        BestellingDTO? GeefBestelling(Guid id);
        List<BestellingDTO> GeefBestellingen();
        IEnumerable<BestellingDTO?> GeefBestellingBijKlantId(Guid klantID);
        void VoegBestellingToe(Guid bestellingId, string beschrijving, KlantDTO klantDTO, CadeaubonDTO cadeaubonDTO, string stripeID);
        void VerwijderBestelling(Guid bestellingId);
        void VoegTransactieToe(string stripeID, decimal prijsBetaald, string beschrijving);
        string GeefStripeId(Guid id);
    }
}
