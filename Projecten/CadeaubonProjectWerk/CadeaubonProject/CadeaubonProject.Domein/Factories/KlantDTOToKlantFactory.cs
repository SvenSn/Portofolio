using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Factories
{
    internal class KlantDTOToKlantFactory
    {
        public static Klant ConvertKlantDTOToKlant(KlantDTO klantdto)
        {
            return new Klant(
                klantdto.KlantId,
                klantdto.Email,
                klantdto.Passwoord,
                klantdto.Voornaam,
                klantdto.Achternaam);
        }
    }
}
