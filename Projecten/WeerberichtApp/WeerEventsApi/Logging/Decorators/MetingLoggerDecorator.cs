using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging.Decorators;

public abstract class MetingLoggerDecorator : IMetingLogger
{
    protected readonly IMetingLogger _innerLogger;

    protected MetingLoggerDecorator(IMetingLogger innerLogger)
    {
        _innerLogger = innerLogger;
        
    }
    

    public virtual void Log(Meting meting)
    {
        _innerLogger.Log(meting);
    }
}
