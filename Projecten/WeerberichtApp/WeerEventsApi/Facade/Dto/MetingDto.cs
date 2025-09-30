using WeerEventsApi.Metingen;

namespace WeerEventsApi.Facade.Dto;

public class MetingDto
{
    public string Locatie { get; init; }
    public DateTime MomentMeting { get; init; }
    public double Waarde { get; init; }
    public string Eenheid { get; init; }
}