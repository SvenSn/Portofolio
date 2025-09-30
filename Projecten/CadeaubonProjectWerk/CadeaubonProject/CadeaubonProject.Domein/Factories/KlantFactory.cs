using CadeaubonProject.Domein.Models;

namespace CadeaubonProject.Domein.Factories;

internal class KlantFactory
{
    internal static Klant CreateNewKlant(Guid klantId, string email, string passwoord, string voornaam, string achternaam)
    {
        return new Klant(klantId,email,passwoord,voornaam, achternaam);  
    }
}
