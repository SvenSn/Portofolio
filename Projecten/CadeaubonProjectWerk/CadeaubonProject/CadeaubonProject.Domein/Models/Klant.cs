using BCrypt.Net;

namespace CadeaubonProject.Domein.Models;

internal class Klant
{
    public Guid KlantId { get; private set; }

    public string Email { get; private set; }

    public string Passwoord { get; private set; }

    public string Voornaam { get; private set; }

    public string Achternaam { get; private set; }

    public Klant(Guid klantId, string email, string normaalPasswoord, string voornaam, string achternaam)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email mag niet leeg zijn.");
        if (!email.Contains('@'))
            throw new ArgumentException("Email moet een @ bevatten.");

        if (string.IsNullOrWhiteSpace(normaalPasswoord))
            throw new ArgumentException("Wachtwoord mag niet leeg zijn.");
        if (normaalPasswoord.Length < 6)
            throw new ArgumentException("Wachtwoord moet minstens 6 tekens bevatten.");

        if (string.IsNullOrWhiteSpace(voornaam))
            throw new ArgumentException("Voornaam mag niet leeg zijn.");

        if (string.IsNullOrWhiteSpace(achternaam))
            throw new ArgumentException("Achternaam mag niet leeg zijn.");

        KlantId = klantId;
        Email = email;
        Passwoord = BCrypt.Net.BCrypt.HashPassword(normaalPasswoord);
        Voornaam = voornaam;
        Achternaam = achternaam;

    }
}
