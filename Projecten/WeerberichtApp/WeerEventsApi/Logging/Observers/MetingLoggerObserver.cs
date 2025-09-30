using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging.Observers;

public class MetingLoggerObserver : ImetingObserver
{
    private readonly IEnumerable<IMetingLogger> _loggers;

    public MetingLoggerObserver(IEnumerable<IMetingLogger> loggers)
    {
        _loggers = loggers;
    }

    public void VerwerkMeting(Meting meting)
    {
        foreach (var logger in _loggers)
        {
            logger.Log(meting);
        }
    }
}
