using BusStops.Domain;
using BusStops.Persistence;
using BusStops.Presentation;

namespace BusStops.Main
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            IBusStopsRepository repository = new BusStopsMapper();
            DomainController domainController = new DomainController(repository);
            BusStopsApplication application = new BusStopsApplication(domainController);

            BusStopsApplication application1 = new BusStopsApplication(domainController);

            application1.Run();

           

        }
    }
}
