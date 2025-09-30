using System.Runtime.CompilerServices;
using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations;

public class TemperatuurWeerstation : Weerstation
{
    private readonly Random random = new Random();

    public TemperatuurWeerstation(Stad locatie) : base(locatie)
    {
    }

    protected override Meting GenereerMeting()
    {
        double waarde = random.NextDouble()* 55 - 15; //40 graden tot -15c 

        return new Meting
        {
            MomentMeting = DateTime.Now,
            Waarde = waarde,
            Eenheid = EenheidsType.GradenCelsius,
            Locatie = this.Stad
        };
    }
}
