using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Factories
{
    internal class KlantToKlantDTOFactory
    {
        public static KlantDTO ConvertKlantToKlantDTO(Klant klant)
        {
            return new KlantDTO(
                klant.KlantId,
                klant.Email,
                klant.Passwoord,
                klant.Voornaam,
                klant.Achternaam);
        }
    }
}
