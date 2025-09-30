using System.Net.Http.Headers;

namespace CadeaubonProject.Domein.Models;

internal class Bestelling
{
    public Guid AankoopId { get; private set; }

    public Klant KlantBestelling { get; private set; }

    public string Beschrijving { get; private set; } // korte beschrijving van de bestelling

    public Cadeaubon CadeaubonBestelling { get; private set; }


    public Bestelling(Guid aankoopId,Klant klant , string beschrijving, Cadeaubon cadeaubon)
    {
        AankoopId = aankoopId;

        if(beschrijving == null || beschrijving.Contains("\t") ||beschrijving.Contains("\n") || String.IsNullOrEmpty(beschrijving))
        {
            throw new ArgumentException("Bechrijving mag niet leeg zijn.");
        }
        else
        {
            Beschrijving = beschrijving;
        }
            
        KlantBestelling = klant;
        CadeaubonBestelling = cadeaubon;
    }
}
