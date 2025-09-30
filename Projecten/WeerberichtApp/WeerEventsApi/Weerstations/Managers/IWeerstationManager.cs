using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations.Managers
{
    public interface IWeerstationManager
    {
        IEnumerable<WeerStationDto> GeefWeerstations(List<StadDto> steden);

        void VoerMetingenUitVoorAlleStations();

        IEnumerable<Meting> GeefMetingen();

        
    }
}
