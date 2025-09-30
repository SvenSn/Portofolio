using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations.Repositories;

namespace WeerEventsApi.Weerstations.Managers;

public class WeerstationManager(IWeerstationRepostiory weerstationRepostiory) : IWeerstationManager
{
    public IEnumerable<Meting> GeefMetingen()
    {
        return weerstationRepostiory.GetMetings();
    }

    public IEnumerable<WeerStationDto> GeefWeerstations(List<StadDto> steden)
    {
        return weerstationRepostiory.GetWeerStations(steden).Select(ws => new WeerStationDto
        {
            stad = ws.Stad,
            WeerstationType = ws.GetType().Name
        });
    }

    public void VoerMetingenUitVoorAlleStations()
    {
         weerstationRepostiory.DoMetingen();
    }
}
