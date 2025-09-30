using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CadeaubonProject.Presentatielaag.Gui.Pages;


public partial class BestellingenPagina : Page
{
    //managers
    private IBestellingManager _bestellingManager;
    private ICadeaubonManager _cadeaubonManager;

    //ingelogde klant
    private KlantDTO _klant;
    private CadeaubonDTO? _cadeaubonDTO;
    private IEnumerable<CadeaubonGebruikDTO>? _cadeaubonGebruiken;


    public BestellingenPagina(IBestellingManager bestellingManager,ICadeaubonManager cadeaubonManager, KlantDTO klant)
    {
        InitializeComponent();

        //managers  
        _bestellingManager = bestellingManager;
        _cadeaubonManager = cadeaubonManager;

        //ingelogde klant
        _klant = klant;

        BestellingenLijstView.ItemsSource = _bestellingManager.GeefBestellingBijKlantId(_klant.KlantId);
    }

    private void BestellingenLijstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var bestelling = (BestellingDTO)BestellingenLijstView.SelectedItem;
        _cadeaubonDTO = (CadeaubonDTO)bestelling.cadeaubonDTO;
        RefreshCadeauGebruik();

    }

    private void RefreshCadeauGebruik()
    {
        _cadeaubonGebruiken = _cadeaubonManager.GeefCadeaubonGebruik(_cadeaubonDTO.Id);
        CadeaubonGebruikList.ItemsSource = _cadeaubonGebruiken;
    }
}
