using System.Reflection.Metadata.Ecma335;
using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Logging.Observers;
using WeerEventsApi.Metingen;
using WeerEventsApi.Steden;

namespace WeerEventsApi.Weerstations;

public abstract class Weerstation
{
    public  Stad Stad { get; init; }
    protected List<Meting> _metingen = new();

    private readonly List<ImetingObserver> _observers = new();

    protected Weerstation(Stad stad)
    {
        Stad = stad;
    }



    //observers toevoegen als ze nog niet zijn toegevoegt //publisher
    public void VoegObserverToe(ImetingObserver observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    //Geeft een kopie van de lijst van metingen terug
    public IEnumerable<Meting> GeefMetingen() => new List<Meting>(_metingen);


    //Voer de meting uit en verwerk meting per observer
    public void VoerMetingUit()
    {
        Meting meting = GenereerMeting();

        _metingen.Add(meting);

        foreach(var observer in _observers)
        {
            observer.VerwerkMeting(meting);
        }
    }

    //abstracte methode om de Metingen te genereren
    protected abstract Meting GenereerMeting();
   
}

