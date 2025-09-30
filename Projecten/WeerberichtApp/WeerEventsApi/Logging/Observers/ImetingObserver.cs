using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging.Observers;

public interface ImetingObserver
{
    void VerwerkMeting(Meting meting);
}
