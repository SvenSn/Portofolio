using Azure;
using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using System.Windows.Controls;

namespace CadeaubonProject.Presentatielaag.Gui.Pages;

/// <summary>
/// Interaction logic for BeginPagina.xaml
/// </summary>
public partial class BeginPagina : Page
{
    //managers 
    private IBestellingManager _bestellingManager;
    private ICadeaubonManager _cadeaubonManager;

    //ingelogde klant
    private KlantDTO _klant;

    public BeginPagina(IBestellingManager bestellingManager,ICadeaubonManager cadeaubonManager, KlantDTO klantDTO)
    {
        InitializeComponent();

        //managers
        _bestellingManager = bestellingManager;
        _cadeaubonManager = cadeaubonManager;

        //ingelogde klant
        _klant = klantDTO;

        //datacontext om welkom + naam te tonen
        DataContext = _klant;
    }

    //click om naar accountpagina te gaan   
    private void Button_Click_Account(object sender, System.Windows.RoutedEventArgs e)
    {
        AccountPagina accountPagina = new AccountPagina(_klant);

        //navigeren naar accountpagina
        NavigationService.Navigate(accountPagina);
    }
    

    //click om naar bestellingen te gaan
    private void Button_Click_Bestellingen(object sender, System.Windows.RoutedEventArgs e)
    {
        BestellingenPagina bestellingenPagina = new BestellingenPagina(_bestellingManager,_cadeaubonManager, _klant);

        //navigeren naar bestellingenpagina
        NavigationService.Navigate(bestellingenPagina);
    }

    private void Button_Click_BestelNu(object sender, System.Windows.RoutedEventArgs e)
    {
        //nieuwe bestelcadeaupaginq maken
        BestelCadeaubonPagina bestelCadeaubonPagina = new BestelCadeaubonPagina(_bestellingManager,_cadeaubonManager, _klant);

        //navigeren naar bestelcadeaubonpagina
        NavigationService.Navigate(bestelCadeaubonPagina);
    }

    private void Button_Click_Redeem(object sender, System.Windows.RoutedEventArgs e)
    {
        //redeempagina aanmaken
        RedeemCadeaubonPagina redeemCadeaubonPagina = new RedeemCadeaubonPagina(_bestellingManager,_cadeaubonManager, _klant);


        //navigeren naar de nieuwe pagina 
        NavigationService.Navigate(redeemCadeaubonPagina);
    }
}
