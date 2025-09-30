using WeerEventsApi.Steden;

namespace WeerEventsApi.Metingen;

public class Meting
{

    public required DateTime MomentMeting { get; set; }
    public required double Waarde { get; set; } 
    public EenheidsType Eenheid { get; set; }
    public Stad Locatie { get; set; }


    public Meting(DateTime momentMeting, double waarde, EenheidsType eenheid, Stad locatie)
    {
        MomentMeting = momentMeting;
        Waarde = waarde;
        Eenheid = eenheid;
        Locatie = locatie;
    }

    public Meting()
    {
    }
}
public enum EenheidsType
{
    KMPerUur,
    MillimeterPerVierkanteMeterPerUur,
    GradenCelsius,
    HectoPascal
}