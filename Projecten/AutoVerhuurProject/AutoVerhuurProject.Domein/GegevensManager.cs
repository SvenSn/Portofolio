
using AutoVerhuurProject.Domein.Interfaces;

namespace AutoVerhuurProject.Domein;

public class GegevensManager(ICSVGegevensRepositoryFull csvGegevensrepo)
{

    private ICSVGegevensRepositoryFull _csvGegevensrepo =
            csvGegevensrepo is null ?
            throw new ArgumentNullException("Klantrepository mag niet null zijn.") :
            csvGegevensrepo;
    public void DatabankLegen()
    {
        _csvGegevensrepo.LeegDatabase();
    }

    public void VerwerkenAutosDB(string bestandspad)
    {
        _csvGegevensrepo.VerwerkAutos(bestandspad);
    }

    public void VerwerkenVestigingenDB(string bestandspad)
    {
        _csvGegevensrepo.VerwerkVestigingen(bestandspad);
    }

    public void VerwerkenKlantenDB(string bestandspad)
    {
        _csvGegevensrepo.VerwerkKlanten(bestandspad);
    }

    public void KoppelenAutosAanVestigingen()
    {
        _csvGegevensrepo.KoppelAutosAanVestigingen();
    }

}
