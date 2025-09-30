using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Interfaces;

namespace AutoVerhuurProject.Domein;

public class KlantManager(IKlantRepositoryRead klantRepositoryRead)
{
    private IKlantRepositoryRead _klantRepositoryRead =
            klantRepositoryRead is null ?
            throw new ArgumentNullException("Klantrepository mag niet null zijn.") :
            klantRepositoryRead;

    public IEnumerable<KlantDTO> GeefAlleKlanten()
    {
        return _klantRepositoryRead.GetAll();
    }
    public KlantDTO GeefKlantBijEmail(string email)
    {
        return _klantRepositoryRead.GetByEmail(email);
    }

    public IEnumerable<KlantDTO> GeefKlantenBijNaam(string naam)
    {
        return _klantRepositoryRead.GetByName(naam);
    }
}
