using WeerEventsApi.Metingen;

namespace WeerEventsApi.Weerberichten;

public class WeerberichtProxy : IWeerberichtGenerator
{
    private readonly IWeerberichtGenerator _generator;
    private Weerbericht _bijgehoudenWeerbericht;
    private DateTime _laatsteTijdGemaaktWeerbericht;


    public WeerberichtProxy(IWeerberichtGenerator generator)
    {
        _generator = generator;
    }

    public Weerbericht GenerateWeerbericht(List<Meting> metingen)
    {
        return (_bijgehoudenWeerbericht != null && (DateTime.Now - _laatsteTijdGemaaktWeerbericht).TotalMinutes < 1)
            ? _bijgehoudenWeerbericht : BijhoudenEnGenereerWeerbericht(metingen);

    }
    // als het langer dan een minuut is geleden is maakt deze methode een nieuw weerbericht
    //en cached die zich in de variabele _bijgegoudenweerbericht
    //reset ook de tijd zo deze weer wordt gecached voor een minuut
    private Weerbericht BijhoudenEnGenereerWeerbericht(List<Meting> metingen)
    {
        _bijgehoudenWeerbericht = _generator.GenerateWeerbericht(metingen);
        _laatsteTijdGemaaktWeerbericht = DateTime.Now;
        return _bijgehoudenWeerbericht;
    }
}
