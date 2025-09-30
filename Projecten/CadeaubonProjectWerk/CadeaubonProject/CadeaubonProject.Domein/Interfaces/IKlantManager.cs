using CadeaubonProject.Domein.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Interfaces
{
    public interface IKlantManager
    {
        KlantDTO? GeefKlantBijEmail(string email);
        KlantDTO? GeefKlantBijId(Guid klantId);
        bool IsKlantGeregistreerd(string email);
        void VoegKlantToe(Guid klantId, string email, string passwoord, string voornaam, string achternaam);
        void VerwijderKlant(Guid klantId);
        bool IsPasswoordJuist(string email, string normaalPasswoord);

    }
}
