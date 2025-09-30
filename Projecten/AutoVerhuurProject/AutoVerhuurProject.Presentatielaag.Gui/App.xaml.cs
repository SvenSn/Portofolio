using AutoVerhuurProject.Domein;
using AutoVerhuurProject.Domein.Interfaces;
using AutoVerhuurProject.Persistentielaag;
using AutoVerhuurProject.Persistentielaag.Database;
using System.IO;
using System.Windows;

namespace AutoVerhuurProject.Presentatielaag.Gui;


public partial class App : Application
{
    private void Application_Startup(object sender, StartupEventArgs e)
    {// repositories aanmaken voor managers 
        IAutoRepositoryRead autorepo = new AutoRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        IKlantRepositoryRead klantenrepo = new KlantRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        IReserveringRepositoryFull reserveringrepo = new ReserveringRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        IVestigingRepositoryRead vestigingrepo = new VestigingRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        ICSVGegevensRepositoryFull csvGegevensrepo = new CSVVerwerkerDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        

        //managers aanmaken
        ReserveringManager rm = new ReserveringManager(reserveringrepo);
        GegevensManager gm = new GegevensManager(csvGegevensrepo);
        VestigingManager vm = new VestigingManager(vestigingrepo);
        AutoManager am = new AutoManager(autorepo);
        KlantManager ka = new KlantManager(klantenrepo);


        //windows aanmaken
        
        GegevensApp gegevens = new GegevensApp(gm,rm);
        KlantenApp klanten = new KlantenApp(ka);
        
        ReservatieApp reservatie = new ReservatieApp(rm, vm, am,klanten);
        KeuzeApp keuzeApp = new KeuzeApp(am, vm, gegevens, rm, klanten,reservatie);

        keuzeApp.Show();

    }
}

