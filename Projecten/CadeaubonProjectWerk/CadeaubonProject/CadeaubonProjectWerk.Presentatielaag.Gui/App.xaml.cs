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
        //repositories aanmaken
        IKlantRepository klantRepo = new KlantRepositoryDB(@"Data Source=cigrit.fortiddns.com,11433;Initial Catalog=Boomers25;Persist Security Info=True;User ID=Boomers25User;Password=AVefhwNpvY5c6P;Trust Server Certificate=True");
        IBestellingRepository bestellingRepo = new BestellingRepositoryDB(@"Data Source=cigrit.fortiddns.com,11433;Initial Catalog=Boomers25;Persist Security Info=True;User ID=Boomers25User;Password=AVefhwNpvY5c6P;Trust Server Certificate=True");
        ICadeaubonRepository cadeaubonRepo = new CadeaubonRepositoryDB(@"Data Source=cigrit.fortiddns.com,11433;Initial Catalog=Boomers25;Persist Security Info=True;User ID=Boomers25User;Password=AVefhwNpvY5c6P;Trust Server Certificate=True");


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

