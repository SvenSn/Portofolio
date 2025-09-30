using WeerEventsApi.Steden;
using WeerEventsApi.Weerstations;

namespace WeerEventsApi.Facade.Dto;

public class WeerStationDto
{
    public required Stad stad {  get; set; }  
    public required string WeerstationType { get; set; }
}