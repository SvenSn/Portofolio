using WeerEventsApi.Metingen;

namespace WeerEventsApi.Weerberichten;

public interface IWeerberichtGenerator
{
    Weerbericht GenerateWeerbericht(List<Meting> metingen);
}
