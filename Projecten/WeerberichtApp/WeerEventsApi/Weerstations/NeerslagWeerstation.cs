using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations;

public class NeerslagWeerstation : Weerstation
{
    private readonly Random _random = new Random();

    public NeerslagWeerstation(Stad stad) : base(stad)
    {
    }

    protected override Meting GenereerMeting()
    {
        double regenKans  = _random.NextDouble();
        double neerslag;
        
        if(_random.NextDouble() > regenKans)
        {
             neerslag = 0.0;
        }
        else
        {
            neerslag = _random.NextDouble() *25.0;// 0-25 mm
        }

        return new Meting
        {
            MomentMeting = DateTime.Now,
            Waarde = neerslag,
            Eenheid = EenheidsType.MillimeterPerVierkanteMeterPerUur,
            Locatie = this.Stad
        };
    }
}
