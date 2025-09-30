using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations;

public class LuchtdrukWeerstation : Weerstation
{
    private readonly Random _random = new Random();

    public LuchtdrukWeerstation(Stad stad) : base(stad)
    {
    }

    protected override Meting GenereerMeting()
    {
        double waarde = 980 + _random.NextDouble() * (1050 - 980); //tussen de 980 - 1050hPa

        return new Meting
        {
            MomentMeting = DateTime.Now,
            Waarde = waarde,
            Eenheid = EenheidsType.HectoPascal,
            Locatie = this.Stad
        };
    }
}
