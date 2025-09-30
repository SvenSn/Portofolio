using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations.Repositories
{
    public interface IWeerstationRepostiory
    {
        List<Weerstation> GetWeerStations(List<StadDto> steden);

        void DoMetingen();

        IEnumerable<Meting> GetMetings();
    }
}
