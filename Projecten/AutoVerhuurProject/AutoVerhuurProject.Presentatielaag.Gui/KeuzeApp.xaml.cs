using AutoVerhuurProject.Domein;
using System.Windows;

namespace AutoVerhuurProject.Presentatielaag.Gui
{
    /// <summary>
    /// Interaction logic for KeuzeApp.xaml
    /// </summary>
    public partial class KeuzeApp : Window
    {
        private GegevensApp _gegevens;
        private ReservatieApp _reservatie;
        private KlantenApp _klanten;
        


        private AutoManager _am;
        private VestigingManager _vm;
        private ReserveringManager _rm;


        public KeuzeApp(AutoManager am,VestigingManager vm,GegevensApp ga,ReserveringManager rm,KlantenApp klanten,ReservatieApp reservatieApp)
        {
            InitializeComponent();
            _am = am;
            _vm = vm;
            _rm = rm;


            //apps 
            _gegevens = ga;
            _klanten = klanten;
            _reservatie = reservatieApp;
            
        }

        private void Button_Click_GegevensApp(object sender, RoutedEventArgs e)
        {
            this.Hide();
            _gegevens.Show();
           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ben je zeker dat je wil afsluiten?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // Prevents window from closing
            }
        }

        private void Click_Button_KlantLogin(object sender, RoutedEventArgs e)
        {
            
            _klanten.Show();
        }

        private void Click_Button_Reservatie(object sender, RoutedEventArgs e)
        {
            
            _reservatie.Show();
        }
    }
}
