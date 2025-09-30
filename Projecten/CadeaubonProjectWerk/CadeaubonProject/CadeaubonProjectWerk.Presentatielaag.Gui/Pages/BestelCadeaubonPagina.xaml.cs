using CadeaubonProject.Domein;
using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using Microsoft.Extensions;
using Stripe;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CadeaubonProject.Presentatielaag.Gui.Pages;


public partial class BestelCadeaubonPagina : Page
{
    private RadioButton _huidigGeselecteerdeRadioButton = null!;
    //managers
    private IBestellingManager _bestellingManager;
    private ICadeaubonManager _cadeaubonManager;

    //cadeaubon
    private CadeaubonDTO _cadeaubon;

    //bestelling
    private BestellingDTO _bestelling;

    //ingelogde klant
    private KlantDTO _klant;


    //thema bijhouden
    ThemaType _thema;

    //prijs bijhouden om bestelling te maken
    decimal _prijs;

    public BestelCadeaubonPagina(IBestellingManager bestellingManager,ICadeaubonManager cadeaubonManager,KlantDTO klant)
    {
        InitializeComponent();

        //managers
        _bestellingManager = bestellingManager;
        _cadeaubonManager = cadeaubonManager;

        //ingelogde klant
        _klant = klant;


        //cadeaubon lijst the values van de thematypes geven 
        CadeaubonTypeLijst.ItemsSource = Enum.GetValues(typeof(ThemaType));


        //opmaak voor custom amountbox
        CustomAmountBox.Text = "Geef uw eigen bedrag in tussen 5 EUR en 50 EUR .";
        CustomAmountBox.Foreground = Brushes.Gray;  
    }

    private void CadeaubonTypeLijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
       if(CadeaubonTypeLijst.SelectedItem is ThemaType selectedThemaType)
        {
            _thema = selectedThemaType;
        }
    }

    private void CustomAmountBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
    {
        if (CustomAmountBox.Foreground == Brushes.Gray)
        {
            CustomAmountBox.Text = "";
            CustomAmountBox.Foreground = Brushes.Black;
        }
    }

    private void CustomAmountBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CustomAmountBox.Text))
        {
            CustomAmountBox.Text = "Geef uw eigen bedrag in tussen 5 EUR en 50 EUR.";
            CustomAmountBox.Foreground = Brushes.Gray;
        }
    }


    private void RadioButton5EUR_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (_huidigGeselecteerdeRadioButton == RadioButton5EUR)
        {
            RadioButton5EUR.IsChecked = false;
            RadioButton5EUR.Background = Brushes.LightGray;
            _huidigGeselecteerdeRadioButton = null;
            _prijs = 0;
        }
        else
        {
            DeselecteerAlleRadioButtons();
            RadioButton5EUR.IsChecked = true;
            _huidigGeselecteerdeRadioButton = RadioButton5EUR;
            _prijs = 5.00m;
            RadioButton5EUR.Background = Brushes.LightSkyBlue;
        }
    }
    

    private void RadioButton20EUR_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (_huidigGeselecteerdeRadioButton == RadioButton20EUR)
        {
            RadioButton20EUR.IsChecked = false;
            RadioButton20EUR.Background = Brushes.LightGray;
            _huidigGeselecteerdeRadioButton = null;
            _prijs = 0;
        }
        else
        {
            DeselecteerAlleRadioButtons();
            RadioButton20EUR.IsChecked = true;
            _huidigGeselecteerdeRadioButton = RadioButton20EUR;
            _prijs = 20.00m;
            RadioButton20EUR.Background = Brushes.LightSkyBlue;
        }
    }

    private void RadioButton50EUR_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if (_huidigGeselecteerdeRadioButton == RadioButton50EUR)
        {
            RadioButton50EUR.IsChecked = false;
            RadioButton50EUR.Background = Brushes.LightGray;
            _huidigGeselecteerdeRadioButton = null;
            _prijs = 0;
        }
        else
        {
            DeselecteerAlleRadioButtons();
            RadioButton50EUR.IsChecked = true;
            _huidigGeselecteerdeRadioButton = RadioButton50EUR;
            _prijs = 50.00m;
            RadioButton50EUR.Background = Brushes.LightSkyBlue;
        }
    }

    private void DeselecteerAlleRadioButtons()
    {
        RadioButton5EUR.Background = Brushes.LightGray;
        RadioButton20EUR.Background = Brushes.LightGray;
        RadioButton50EUR.Background = Brushes.LightGray;

        RadioButton5EUR.IsChecked = false;
        RadioButton20EUR.IsChecked = false;
        RadioButton50EUR.IsChecked = false;
    }


    private void CustomAmountBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (decimal.TryParse(CustomAmountBox.Text, out decimal customAmount))
        {
            _prijs = customAmount;
            CustomAmountBox.Foreground = Brushes.Black;
        }
    }



    private void BestellenButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        _cadeaubon = new CadeaubonDTO(Guid.NewGuid(), _prijs, _thema, DateTime.Now.AddYears(1));
        _bestelling = new BestellingDTO(Guid.NewGuid(), $"{_cadeaubon.Thematype} cadeaubon met {_cadeaubon.Saldo} EUR waarde gekocht op {_cadeaubon.Datum.ToString("dd-MM-yyyy")}",_klant,_cadeaubon);

        BetalingsPagina betalingsPagina = new BetalingsPagina(_bestellingManager,_cadeaubonManager,_klant,_bestelling,_cadeaubon);

        NavigationService?.Navigate(betalingsPagina);
    }

}
