using System.Text.Json;
using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Logging.Observers;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger, ImetingObserver
{
    public void Log(Meting meting)
    {
        Console.WriteLine($"{meting.Locatie.Naam},{meting.Waarde} {meting.Eenheid}");
    }

    public void VerwerkMeting(Meting meting)
    {
        Log(meting);
    }
}