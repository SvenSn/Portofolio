using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Factories;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Models;

namespace CadeaubonProject.Domein.Managers;

public class KlantManager(IKlantRepository klantRepository): IKlantManager
{
    private IKlantRepository _klantrepoFull = klantRepository is null ?
        throw new ArgumentNullException("Repository mag niet leeg zijn.") : klantRepository;


    public KlantDTO? GeefKlantBijEmail(string email)
    {
        return _klantrepoFull.GetByEmail(email);
    }

    public KlantDTO? GeefKlantBijId(Guid klantId)
    {
        return _klantrepoFull.GetById(klantId);
    }

    public bool IsKlantGeregistreerd(string email)
    {
        if (GeefKlantBijEmail(email) == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void VoegKlantToe(Guid klantId, string email, string passwoord, string voornaam, string achternaam)
    {
        Klant klant = KlantFactory.CreateNewKlant(Guid.NewGuid(), email, passwoord, voornaam, achternaam);

        KlantDTO klantDTO = KlantToKlantDTOFactory.ConvertKlantToKlantDTO(klant);

        _klantrepoFull.Add(klantDTO);
    }

    public void VerwijderKlant(Guid klantId)
    {
        _klantrepoFull.Delete(klantId);
    }

    public bool IsPasswoordJuist(string email, string normaalPasswoord)
    {

        KlantDTO? klant = GeefKlantBijEmail(email);

        return BCrypt.Net.BCrypt.Verify(normaalPasswoord, klant.Passwoord);
    }

}
