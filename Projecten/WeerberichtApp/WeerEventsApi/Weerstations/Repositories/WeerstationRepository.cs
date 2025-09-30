using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Observers;
using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Weerstations.Factories;

namespace WeerEventsApi.Weerstations.Repositories
{
    public class WeerstationRepository : IWeerstationRepostiory
    {

        private readonly List<Weerstation> _weerstations;

        private readonly IEnumerable<IMetingLogger> _metingLogger;


        public WeerstationRepository(IStadRepository stadRepository,IEnumerable<IMetingLogger> metingLogger)
        {
            var steden = stadRepository.GetSteden().Select(s => new StadDto
            {
                Naam = s.Naam,
                Beschrijving = s.Beschrijving,
                GekendVoor = s.GekendVoor
            }).ToList();
            _metingLogger = metingLogger;
            _weerstations = WeerstationFactory.MaakWeerstations(steden);
        }

        public void DoMetingen()
        {
            foreach (var station in _weerstations)
            {
                station.VoegObserverToe(new MetingLoggerObserver(_metingLogger));
                station.VoerMetingUit();
            }
        }

        public IEnumerable<Meting> GetMetings()
        {
            var allMetingen = new List<Meting>();

            foreach (var station in _weerstations)
            {
                allMetingen.AddRange(station.GeefMetingen());
            }

            return allMetingen;
        }

        public List<Weerstation> GetWeerStations(List<StadDto> steden)
        {
            return _weerstations;
        }

    }
}
