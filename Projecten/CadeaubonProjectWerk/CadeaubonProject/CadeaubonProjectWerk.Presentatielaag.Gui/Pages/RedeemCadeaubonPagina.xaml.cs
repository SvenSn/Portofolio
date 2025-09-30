using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CadeaubonProject.Presentatielaag.Gui.Pages;

public partial class RedeemCadeaubonPagina : Page
{
    private IBestellingManager _bestellingManager;
    private ICadeaubonManager _cadeaubonManager;

    private CadeaubonDTO _cadeaubon;
    private BestellingDTO _bestellingDTO;
    private KlantDTO _klant;

    private decimal _bedrag;
    private string _winkel;

    public ObservableCollection<BestellingDTO> Bestellingen { get; set; } = new();

    public ObservableCollection<string> Winkels { get; } = new ObservableCollection<string>
        {
            "Bol.com",
            "Alternate.be",
            "Dreamland",
            "Steam",
            "Kruidvat"
        };
    public RedeemCadeaubonPagina(IBestellingManager bestellingManager,ICadeaubonManager cadeaubonManager, KlantDTO klant)
    {
        _bestellingManager = bestellingManager;
        _cadeaubonManager = cadeaubonManager;

        _klant = klant;
        DataContext = this;
        InitializeComponent();

        RefreshLijstBestellingen();
        BestellingenListBox.ItemsSource = Bestellingen;
    }

    public void RefreshLijstBestellingen()
    {
        Bestellingen.Clear();
        var nieuweBestellingenLijst = _bestellingManager.GeefBestellingBijKlantId(_klant.KlantId)
            .Where(b => b.cadeaubonDTO.Datum >= DateTime.Now && b.cadeaubonDTO.Saldo > 0);
        foreach (var b in nieuweBestellingenLijst)
        {
            Bestellingen.Add(b);
        }
    }

    private void Preview_TextInput_Nummer(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
        //aleen decimalen toestaan 
        e.Handled = !decimal.TryParse(e.Text, out _);
    }

    private void TextBoxBedrag_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (decimal.TryParse(TextBoxBedrag.Text, out decimal bedrag))
        {
            _bedrag = bedrag;
        }

    }

    private void btnRedeem_Click(object sender, System.Windows.RoutedEventArgs e)
    {

        if (_cadeaubon.Saldo <= 0 || _cadeaubon.Saldo < _bedrag || _bestellingDTO == null)
        {
            MessageBox.Show("De cadeaubon heeft onvoldoende saldo of er is geen cadeaubon geselecteerd");
        }
        else
        {
            _cadeaubonManager.UpdateCadeaubon(_cadeaubon.Id, _bedrag);
            _cadeaubonManager.VoegCadeaubonGebruikToe(_cadeaubon.Id, _winkel, DateTime.Now, _bedrag);
            NavigationService.GoBack();

        }
    }

    private void BestellingenListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _bestellingDTO = (BestellingDTO)BestellingenListBox.SelectedItem;
        _cadeaubon = (CadeaubonDTO) _bestellingDTO.cadeaubonDTO;


    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _winkel = (string)((ComboBox)sender).SelectedItem;
    }
}
