using System.Text.Json;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging.Decorators;

public class JSONMetingLoggerDecorator : MetingLoggerDecorator
{
    private readonly string _jsonPad = "C:\\Users\\compl\\Desktop\\EindOpracht_SO2\\WeerStart\\WeerEventsApi\\log.json";

    public JSONMetingLoggerDecorator(IMetingLogger metingLogger) : base(metingLogger)
    {

    }

    public override void Log(Meting meting)
    {
        base.Log(meting);

        string jsonInvoer = JsonSerializer.Serialize(meting) + Environment.NewLine;

        File.AppendAllText(_jsonPad, jsonInvoer);
    }

}
