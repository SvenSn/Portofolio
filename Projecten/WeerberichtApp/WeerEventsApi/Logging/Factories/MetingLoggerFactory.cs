using WeerEventsApi.Logging.Decorators;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging.Factories;

public static class MetingLoggerFactory
{
    public static IMetingLogger Create(bool decorateWithJson, bool decorateWithXml)
    {
        IMetingLogger metingLogger = new MetingLogger();

        return (decorateWithXml, decorateWithJson) switch
        {
            (false, false) => metingLogger,
            (false, true) => new JSONMetingLoggerDecorator(metingLogger),
            (true, false) => new XMLMetingLoggerDecorator(metingLogger),
            (true, true) => new JSONMetingLoggerDecorator(new XMLMetingLoggerDecorator(metingLogger))
        };
    }
}