using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Managers;
using CadeaubonProjectWerk.Presentatielaag.Gui;
using System.Windows;
using System.Windows.Media;

namespace CadeaubonProject.Presentatielaag.Gui;

/// <summary>
/// Interaction logic for KlantRegistreren.xaml
/// </summary>
public partial class KlantRegistreren : Window
{
    private IKlantManager _klantManager;

    private IBestellingManager _bestellingManager;
    private ICadeaubonManager _cadeaubonManager;



    public KlantRegistreren(IKlantManager klantManager)
    {
        InitializeComponent();
        _klantManager = klantManager;

        //placehold tekst grijs zetten bij aanmaak klant voornaam
        VoornaamKlant.Text = "Voornaam";
        VoornaamKlant.Foreground = Brushes.Gray;

        //placehold tekst grijs zetten bij aanmaak klant achternaam
        AchternaamKlant.Text = "Achternaam";
        AchternaamKlant.Foreground = Brushes.Gray;

        //placehold tekst grijs zetten bij aanmaak klant email 
        EmailKlant.Text = "Email";
        EmailKlant.Foreground = Brushes.Gray;

       

    }

    private void Button_Click_RegistreerKlant(object sender, RoutedEventArgs e)
    {
        string voornaam = "";
        string achternaam = "";
        string email = "";
        string paswoord = "";

        bool IsAllesGeslaagt = true;

        


        //voornaam condities
        if(VoornaamKlant.Text != "Voornaam" && !string.IsNullOrEmpty(VoornaamKlant.Text))
        {
            voornaam = VoornaamKlant.Text;
        }
        else
        {
            MessageBox.Show("Voornaam mag niet leeg zijn.");
            IsAllesGeslaagt = false;
        }

        //achternaam condities
        if (AchternaamKlant.Text != "Achternaam" && !string.IsNullOrEmpty(AchternaamKlant.Text))
        {
            achternaam = AchternaamKlant.Text;
        }
        else
        {
            MessageBox.Show("Achternaam mag niet leeg zijn.");
            IsAllesGeslaagt = false;
        }

        //email condities
        if (EmailKlant.Text != "Email" && !string.IsNullOrEmpty(EmailKlant.Text) && EmailKlant.Text.Contains('@') && EmailKlant.Text.Contains('.') && _klantManager.GeefKlantBijEmail(email) == null)
        {
            email = EmailKlant.Text;
        }
        else
        {
            MessageBox.Show("Email mag niet leeg zijn.");
            IsAllesGeslaagt = false;
        }

        //passwoord condities
        if(!string.IsNullOrEmpty(PasswoordKlant.Password) && PasswoordKlant.Password.Length > 6 )
        {
            paswoord = PasswoordKlant.Password;
        }
        else
        {
            MessageBox.Show("Passwoord mag niet leeg zijn of korter zijn dan 6 karakters.");
            IsAllesGeslaagt = false;
        }

       if(IsAllesGeslaagt == true)
        {
            _klantManager.VoegKlantToe(Guid.NewGuid(), email, paswoord, voornaam, achternaam);
            MessageBox.Show($"Bedankt om u zich te registreren {voornaam}");
            KlantLogin klantlogin = new KlantLogin(_klantManager,_bestellingManager,_cadeaubonManager);
            klantlogin.Show();           
            this.Close();
        } 
    }

    private void VoornaamTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(VoornaamKlant.Text))
        {
            VoornaamKlant.Text = "Voornaam";
            VoornaamKlant.Foreground = Brushes.Gray;
        }
    }

    private void VoornaamTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if(VoornaamKlant.Foreground == Brushes.Gray)
        {
            VoornaamKlant.Text = "";
            VoornaamKlant.Foreground = Brushes.Black;
        }
    }

    private void AchternaamTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (AchternaamKlant.Foreground == Brushes.Gray)
        {
            AchternaamKlant.Text = "";
            AchternaamKlant.Foreground = Brushes.Black;
        }
    }

    private void AchternaamTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(AchternaamKlant.Text))
        {
            AchternaamKlant.Text = "Achternaam";
            AchternaamKlant.Foreground = Brushes.Gray;
        }
    }

    private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (EmailKlant.Foreground == Brushes.Gray)
        {
            EmailKlant.Text = "";
            EmailKlant.Foreground = Brushes.Black;
        }
    }

    private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EmailKlant.Text))
        {
            EmailKlant.Text = "Email";
            EmailKlant.Foreground = Brushes.Gray;
        }
    }

    private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(PasswoordKlant.Password))
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }
    }

    private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(PasswoordKlant.Password))
        {
            PasswordPlaceholder.Visibility = Visibility.Visible;
        }
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(PasswoordKlant.Password))
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }
        else
        {
            PasswordPlaceholder.Visibility = Visibility.Visible;
        }
    }
}
