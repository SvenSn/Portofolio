using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Weerberichten;
using WeerEventsApi.Weerstations.Managers;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly IWeerstationManager _weerstationManager;
    private readonly IWeerberichtGenerator _weerberichtGenerator;


    public DomeinController(IStadManager stadManager,IWeerstationManager weerstationManager,IWeerberichtGenerator weerberichtGenerator)
    {
        _stadManager = stadManager;
        _weerstationManager = weerstationManager;
        _weerberichtGenerator = weerberichtGenerator;
    }

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        });
    }

    public IEnumerable<WeerStationDto> GeefWeerstations()
    {
        var stedenDto = _stadManager.GeefSteden().Select(s => new StadDto
        {
            Naam = s.Naam,
            Beschrijving = s.Beschrijving,
            GekendVoor = s.GekendVoor
        }).ToList();

        return _weerstationManager.GeefWeerstations(stedenDto);
    }

    public IEnumerable<MetingDto> GeefMetingen()
    {

        return _weerstationManager.GeefMetingen()
            .Select(m => new MetingDto
            {
                Locatie = m.Locatie.Naam,
                MomentMeting = m.MomentMeting,
                Eenheid = m.Eenheid.ToString(),
                Waarde = m.Waarde
            });
    }

    public void DoeMetingen()
    {
        _weerstationManager.VoerMetingenUitVoorAlleStations();
    }

    public WeerBerichtDto GeefWeerbericht()
    {
        var metingen = _weerstationManager.GeefMetingen().ToList();
       Weerbericht weerbericht = _weerberichtGenerator.GenerateWeerbericht(metingen);


        return new WeerBerichtDto
        {
            Moment = weerbericht.Moment,
            Inhoud = weerbericht.Inhoud
        };
    }
}