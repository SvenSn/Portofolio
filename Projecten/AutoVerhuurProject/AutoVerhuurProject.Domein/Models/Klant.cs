using System.Diagnostics;

namespace AutoVerhuurProject.Domein.Models;

internal class Klant(string voorNaam,string achterNaam,string email)
{
    public string Voornaam { get; private set; } =
       !String.IsNullOrEmpty(voorNaam) && !voorNaam.Contains("\t") && !voorNaam.Contains("\n") ? voorNaam : throw new ArgumentNullException(nameof(voorNaam),"Voornaam mag niet leeg zijn.");
    
    public  string Achternaam { get; private set; } =
        !String.IsNullOrEmpty(achterNaam) && !achterNaam.Contains("\t") && !achterNaam.Contains("\n") ? achterNaam : throw new ArgumentNullException(nameof(achterNaam), "Achternaam mag niet leeg zijn.");

    public string Email { get; private set; } =
        !String.IsNullOrEmpty(email) && !email.Contains("\t") && !email.Contains("\n") ? email : throw new ArgumentNullException(nameof(Email), "Email mag niet leeg zijn.");
    public string Straat { get; private set; }

    public string Postcode { get; private set; }

    public string Woonplaats { get; private set; }

    public string Land {  get; private set; }

    public Klant(string voornaam, string achternaam, string email,string straat,string postcode,string woonplaats,string land) :
        this(voornaam,achternaam,email)
    {
        Voornaam = voornaam;
        Achternaam = achternaam;
        Email = email;
        Straat = straat;
        Postcode = postcode;
        Woonplaats = woonplaats;
        Land = land;

    }


    private List<Reservering> _reserveringen;


    public void VoegReserveringToe(Reservering reservering)
    {
        if (_reserveringen.Contains(reservering))
        {
            throw new ArgumentException("Deze reservering bestaat al");
        }
        else
        {
            _reserveringen.Add(reservering);
        }
    }


    public List<Reservering> GeefAlleReserveringen()
    {
        return _reserveringen;
    }
}
