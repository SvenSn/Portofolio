using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Stripe;
using Stripe.V2;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CadeaubonProject.Presentatielaag.Gui.Pages;

public partial class BetalingsPagina : Page
{
    //klant en cadeaubon
    KlantDTO _klant;
    CadeaubonDTO _cadeaubon;
    BestellingDTO _bestelling;

    //managers
    private IBestellingManager _bestellingManager;
    private ICadeaubonManager _cadeaubonManager;





    public BetalingsPagina(IBestellingManager bestellingManager,ICadeaubonManager cadeaubonManager,KlantDTO klant,BestellingDTO bestelling,CadeaubonDTO cadeaubon)
    {
        InitializeComponent();
        _bestellingManager = bestellingManager;
        _cadeaubonManager = cadeaubonManager;
        _klant = klant; 
        _bestelling = bestelling;
        _cadeaubon = cadeaubon;
        CadeaubonInfo.Content = $"Cadeaubon voor {_bestelling.cadeaubonDTO.Thematype} \n Waarde: €{_bestelling.cadeaubonDTO.Saldo}";
    }

    private void Button_Click_Betalen(object sender, System.Windows.RoutedEventArgs e)
    {

        bool nummerOk = int.TryParse(VisaNummerBox.Text, out int VisaNummer) && !VisaNummerBox.Text.IsNullOrEmpty();
        bool ccvOK = int.TryParse(VisaCCVBox.Text, out int visaCCV) && !VisaCCVBox.Text.IsNullOrEmpty();
        if (nummerOk && ccvOK)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string apikey = config["Stripe:SecretKey"];

            var client = new StripeClient(apikey);

            var options = new ChargeCreateOptions
            { 
                Amount = (long)_bestelling.cadeaubonDTO.Saldo * 100, // Bedrag in centen dus maal honderd doen 
                Currency = "eur",
                //aleen visa voor dit project kan meerde toevoegen 
                Source = "tok_visa",
                Description = _bestelling.Beschrijving + "\n Cadeaubonnummer is: " + _bestelling.cadeaubonDTO.Id,
                ReceiptEmail = _bestelling.klantDTO.Email

            };
            
            var service = new ChargeService(client);
            var charge = service.Create(options);
            try
            {

                _cadeaubonManager.VoegCadeaubonToe(_cadeaubon.Id, _cadeaubon.Saldo, _cadeaubon.Thematype, _cadeaubon.Datum);
                _bestellingManager.VoegTransactieToe(charge.Id, (decimal)charge.Amount / 100, charge.Description);
                _bestellingManager.VoegBestellingToe(_bestelling.AankoopId, _bestelling.Beschrijving, _bestelling.klantDTO, _bestelling.cadeaubonDTO, charge.Id);
            }
            catch (Exception ex)
            {
                var refundService = new RefundService(client);
                var refundOptions = new RefundCreateOptions
                {
                    Charge = charge.Id,
                    Reason = "Er iets fout gelopen met de toevoeging van bestelling of transactie"

                };

                refundService.Create(refundOptions);

                MessageBox.Show(refundOptions.Reason);
            }



            MessageBox.Show($"Bedankt om hier te shoppen {_bestelling.klantDTO.Voornaam} !");

            NavigationService.GoBack();
            
        }
        else if (!nummerOk)
        {
            MessageBox.Show("Visanummer mag niet leeg zijn en moet een getal zijn.");
        }
        else if (!ccvOK)
        {
            MessageBox.Show("VisaCCV moet een getal zijn en mag niet leeg zijn!");
        }
            
    }
}
