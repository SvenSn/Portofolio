using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations;

public class WindWeerstation : Weerstation
{

    private readonly Random random = new Random();

    public WindWeerstation(Stad stad) : base(stad)
    {
    }

    protected override Meting GenereerMeting()
    {
        double waarde = random.NextDouble() * 70 ; //tot 70kmh

        return new Meting
        {
            MomentMeting = DateTime.Now,
            Waarde = waarde,
            Eenheid = EenheidsType.KMPerUur,
            Locatie = this.Stad
        };
    }
}
