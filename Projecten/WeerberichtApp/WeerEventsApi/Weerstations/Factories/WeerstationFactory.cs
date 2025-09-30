using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations.Factories;

public class WeerstationFactory
{
    private static readonly Random _random = new Random();

    public static List<Weerstation> MaakWeerstations(List<StadDto> stedendto)
    {
        var stations = new List<Weerstation>();
        var steden = stedendto.Select(s => new Stad
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor,
        }).ToList();

        for(int i = 0;i < 12; i++)
        {
            Stad stad = steden[_random.Next(steden.Count)];


            int index = _random.Next(4);

            Weerstation station = index switch
            {
                0 => new TemperatuurWeerstation(stad),
                1 => new WindWeerstation(stad),
                2 => new LuchtdrukWeerstation(stad),
                3 => new NeerslagWeerstation(stad),
                _ => throw new InvalidOperationException("Onbekend type weerstation")
            };
            stations.Add(station);
        }

        return stations;
    }
}
