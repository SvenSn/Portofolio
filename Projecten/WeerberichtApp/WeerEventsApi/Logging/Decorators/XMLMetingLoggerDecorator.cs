using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging.Decorators;

public class XMLMetingLoggerDecorator : MetingLoggerDecorator
{
    private readonly string _xmlPad = "C:\\Users\\compl\\Desktop\\EindOpracht_SO2\\WeerStart\\WeerEventsApi\\log.xml";

    public XMLMetingLoggerDecorator(IMetingLogger logger) : base(logger) 
    { 

    }

    public override void Log(Meting meting)
    {
        base.Log(meting);

        string xmlInvoer = $@"
            <Meting>
                 <Moment>{meting.MomentMeting}</Moment>
                 <Waarde>{meting.Waarde}</Waarde>
                 <Eenheid>{meting.Eenheid}</Eenheid>
            </Meting>";

        File.AppendAllText(_xmlPad, xmlInvoer + Environment.NewLine);
    }
}
