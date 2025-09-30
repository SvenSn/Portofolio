using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Weerberichten;
using WeerEventsApi.Weerstations.Managers;
using WeerEventsApi.Weerstations.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(false,false));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<IWeerstationRepostiory, WeerstationRepository>();
builder.Services.AddSingleton<IWeerstationManager, WeerstationManager>();
builder.Services.AddSingleton<IWeerberichtGenerator, WeerberichtGenerator>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();

var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");

app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());

app.MapGet("/weerstations", (IDomeinController DomeinController) => DomeinController.GeefWeerstations());
app.MapGet("/POST/commands/meting-command", (IDomeinController dc) => dc.DoeMetingen());
app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());
app.MapGet("/weerbericht",(IDomeinController dc) => dc.GeefWeerbericht());  




app.Run();