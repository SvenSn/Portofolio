using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using CadeaubonProject.Presentatielaag.Gui;
using System.Windows;
using System.Windows.Media;

namespace CadeaubonProjectWerk.Presentatielaag.Gui;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class KlantLogin : Window
{

    private IKlantManager _klantManager;

    private IBestellingManager _bestellingManager;

    private ICadeaubonManager _cadeaubonManager;


    public KlantLogin(IKlantManager klantManager,IBestellingManager bestellingManager,ICadeaubonManager cadeaubonManager)
    {
        InitializeComponent();
        _klantManager = klantManager;
        _bestellingManager = bestellingManager;
        _cadeaubonManager = cadeaubonManager;


        //placehold tekst grijs zetten bij aanmaak klant email 
        EmailKlantLogin.Text = "Email";
        EmailKlantLogin.Foreground = Brushes.Gray;

    }

    private void Button_Click_Login(object sender, RoutedEventArgs e)
    {
        string email = EmailKlantLogin.Text;
        string passwoord = PasswoordKlantLogin.Password;
        KlantDTO? klant = _klantManager.GeefKlantBijEmail(email);

        if(_klantManager.IsKlantGeregistreerd(email) == false)
        {
            LoginMeldingen.Text = "Email nog niet geregistreerd.";
        }
        else if (_klantManager.IsKlantGeregistreerd(email) == true && _klantManager.IsPasswoordJuist(email,passwoord) == false)
        {
            LoginMeldingen.Text = "Passwoord is onjuist.";
        }
        else
        {
            LoginMeldingen.Text = "";
            //klant meegeven aan volgend scherm
            KlantDTO klantdto = _klantManager.GeefKlantBijEmail(email);

            BestellingMaken bestellingMaken = new BestellingMaken(_bestellingManager,_cadeaubonManager,klantdto);

            bestellingMaken.Show(); 
            this.Close();
        }
    }

    private void Button_Click_Registreer(object sender, RoutedEventArgs e)
    {
        KlantRegistreren klantRegistreren = new KlantRegistreren(_klantManager);
        klantRegistreren.Show();
        this.Close();
    }

    private void EmailLoginTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (EmailKlantLogin.Foreground == Brushes.Gray)
        {
            EmailKlantLogin.Text = "";
            EmailKlantLogin.Foreground = Brushes.Black;
        }
    }

    private void EmailLoginTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EmailKlantLogin.Text))
        {
            EmailKlantLogin.Text = "Achternaam";
            EmailKlantLogin.Foreground = Brushes.Gray;
        }
    }

    private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(PasswoordKlantLogin.Password))
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }
    }

    private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(PasswoordKlantLogin.Password))
        {
            PasswordPlaceholder.Visibility = Visibility.Visible;
        }
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(PasswoordKlantLogin.Password))
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }
        else
        {
            PasswordPlaceholder.Visibility = Visibility.Visible;
        }
    }
}