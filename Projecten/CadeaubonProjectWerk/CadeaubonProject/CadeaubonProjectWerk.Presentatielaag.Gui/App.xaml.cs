using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using CadeaubonProject.PersistentieLaag.Databank;
using CadeaubonProject.Domein;
using System.Windows;
using CadeaubonProject.PersistentieLaag;


namespace CadeaubonProjectWerk.Presentatielaag.Gui;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {
        string connectionString = Environment.GetEnvironmentVariable("CADEAUBON_DB_CONNECTION_STRING")
            ?? throw new InvalidOperationException(
                "Stel CADEAUBON_DB_CONNECTION_STRING in voordat je de applicatie start.");

        //repositories aanmaken
        IKlantRepository klantRepo = new KlantRepositoryDB(connectionString);
        IBestellingRepository bestellingRepo = new BestellingRepositoryDB(connectionString);
        ICadeaubonRepository cadeaubonRepo = new CadeaubonRepositoryDB(connectionString);


        //managers aanmaken 
        IKlantManager klantManager = new KlantManager(klantRepo);
        IBestellingManager bestellingManager = new BestellingManager(bestellingRepo);
        ICadeaubonManager cadeaubonManager = new CadeaubonManager(cadeaubonRepo);    


        //begin scherm aanmaken
        KlantLogin ka = new KlantLogin(klantManager,bestellingManager,cadeaubonManager);

        //scherm tonen in dit geval het login scherm.
        ka.Show();
    }
}

