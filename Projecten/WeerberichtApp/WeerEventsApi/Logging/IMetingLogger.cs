using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging;

public interface IMetingLogger
{
    void Log(Meting meting);

}