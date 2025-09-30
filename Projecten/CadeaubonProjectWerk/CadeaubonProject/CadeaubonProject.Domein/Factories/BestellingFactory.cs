using CadeaubonProject.Domein.Models;

namespace CadeaubonProject.Domein.Factories
{
    internal class BestellingFactory
    {
        internal static Bestelling CreateNewBestelling(Guid bestellingId, Klant klant, string beschrijving, Cadeaubon cadeaubon)
        {
            return new Bestelling(bestellingId, klant, beschrijving, cadeaubon);
        }

    }
}
