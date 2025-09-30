using AutoVerhuurProject.Domein;
using AutoVerhuurProject.Domein.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoVerhuurProject.Presentatielaag.Gui
{
    /// <summary>
    /// Interaction logic for KlantenApp.xaml
    /// </summary>
    public partial class KlantenApp : Window
    {

        private KlantDTO _geselecteerdeKlant;

        private KlantManager _ka;

        private ReservatieApp _reservatie;
        public KlantenApp(KlantManager klantmanager)
        {
            InitializeComponent();

            _ka = klantmanager;
           

            KlantenLijstView.ItemsSource = _ka.GeefAlleKlanten();
            FilterBy.ItemsSource = new List<string> { "Voornaam", "Achternaam" };
            KlantenLijstView.Items.Filter = GetFilter();
        }

        private void KlantenLijstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (KlantenLijstView.SelectedItem == null)
            {
                MessageBox.Show("U heeft geen klant ingegeven!");
            }
            else
            {
                _geselecteerdeKlant = (KlantDTO)KlantenLijstView.SelectedItem;
            }
        }
        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case "Voornaam": return VoornaamFilter;
                case "Achternaam": return AchternaamFilter;

            }
            return VoornaamFilter;
        }

        private bool AchternaamFilter(object obj)
        {
            var achternaamfilter = obj as KlantDTO;

            return achternaamfilter.Achternaam.Contains(Textfilternaam.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool VoornaamFilter(object obj)
        {
            var naamFilter = obj as KlantDTO;

            return naamFilter.Voornaam.Contains(Textfilternaam.Text, StringComparison.OrdinalIgnoreCase);
        }

        private void Textfilternaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Textfilternaam.Text == null)
            {
                KlantenLijstView.Items.Filter = null;
            }
            else
            {
                KlantenLijstView.Items.Filter = GetFilter();
            }
        }

        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KlantenLijstView.Items.Filter = GetFilter();
        }

        public KlantDTO GeefKlantTerug()
        {
            return _geselecteerdeKlant;
        }

        private void Click_Button_Login(object sender, RoutedEventArgs e)
        {
            this.Hide();
            
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
