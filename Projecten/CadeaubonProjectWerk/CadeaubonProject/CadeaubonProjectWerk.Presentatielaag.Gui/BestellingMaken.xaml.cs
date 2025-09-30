using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using CadeaubonProject.Presentatielaag.Gui.Pages;
using System.Windows;

namespace CadeaubonProject.Presentatielaag.Gui
{
    /// <summary>
    /// Interaction logic for BestellingMaken.xaml
    /// </summary>
    public partial class BestellingMaken : Window
    {

        //managers
        private IBestellingManager _bestellingManager;
        private ICadeaubonManager _cadeaubonManager;


        //klant meegegeven van in te loggen
        private KlantDTO _klant;


        public BestellingMaken(IBestellingManager bestellingManager,ICadeaubonManager cadeaubonManager, KlantDTO klant)
        {
            InitializeComponent();

            _klant = klant;
            _bestellingManager = bestellingManager;
            _cadeaubonManager = cadeaubonManager;   

            //naar de beginpagina gaan
            BeginPaginaFrame.Navigate(new BeginPagina(_bestellingManager,_cadeaubonManager,_klant));

        }

    }
}
