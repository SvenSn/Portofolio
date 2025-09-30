using AutoVerhuurProject.Domein;
using AutoVerhuurProject.Persistentielaag;
using System.Windows;

namespace AutoVerhuurProject.Presentatielaag.Gui
{
    /// <summary>
    /// Interaction logic for GegevensApp.xaml
    /// </summary>
    public partial class GegevensApp : Window
    {
        private ReservatieApp _reservatieApp;
        private ReserveringManager _rm;
        private VestigingManager _vm;
        private AutoManager _am;

        private const string klanten = "C:\\Users\\compl\\Documents\\GitHubRep\\Programmeren\\ProgGov\\Portifolio\\AutoVerhuurProject\\Data\\Klanten.csv";
        private const string autos = "C:\\Users\\compl\\Documents\\GitHubRep\\Programmeren\\ProgGov\\Portifolio\\AutoVerhuurProject\\Data\\Autos.csv";
        private const string vestigingen = "C:\\Users\\compl\\Documents\\GitHubRep\\Programmeren\\ProgGov\\Portifolio\\AutoVerhuurProject\\Data\\Vestigingen.csv";


        private GegevensManager _gm;
  

        public GegevensApp(GegevensManager gm,ReserveringManager rm)
        {
            
            InitializeComponent();
            _gm = gm;
            _rm = rm;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _gm.DatabankLegen();
                MessageBox.Show("De databank werd succesvol geleegd.");
            }
            catch
            {
                MessageBox.Show("Fout bij get legen van de databank.");
            }
            
        }

        private void Button_Click_Initialiseer(object sender, RoutedEventArgs e)
        {
            try
            {
                _gm.VerwerkenKlantenDB(klanten);
                _gm.VerwerkenAutosDB(autos);
                _gm.VerwerkenVestigingenDB(vestigingen);
                MessageBox.Show("Gegevens werden succesvol uitgelezen en weggeschreven.");
            }
            catch
            {
                MessageBox.Show("Gegevens werden niet succesvol uitgelezen en weggeschreven.");
            }
        }

        private void Button_Click_AutoToekennen(object sender, RoutedEventArgs e)
        {
            try
            {
                _gm.KoppelenAutosAanVestigingen();
                MessageBox.Show("De Autos werden succesvol aan een vestiging gekoppeld.");

            }
            catch
            {
                MessageBox.Show("Autos konnen niet worden toegekent aan een vestiging");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ben je zeker dat je wil afsluiten?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
