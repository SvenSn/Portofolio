using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Interfaces;

namespace AutoVerhuurProject.Domein;

public class AutoManager(IAutoRepositoryRead autoRepositoryRead)
{
    private IAutoRepositoryRead _autoRepositoryRead = autoRepositoryRead is null ?
        throw new ArgumentNullException("De autorepository mag niet leeg zijn.") 
        : autoRepositoryRead;

    public IEnumerable<AutoDTO> GeefAlleAutos()
    {
        return _autoRepositoryRead.GetAll();
    }

    public void UpdateVestigingVanAuto(AutoDTO auto, string luchthaven)
    {
        autoRepositoryRead.Update(auto, luchthaven);
    }

    public AutoDTO GeefAutoBijNummerplaat(string nummerplaat)
    {
        return _autoRepositoryRead.GetByNummerplaat(nummerplaat);
    }

    public IEnumerable<AutoDTO> GeefAutosBijVestiging(string luchthaven)
    {
        return _autoRepositoryRead.GetByVestiging(luchthaven);
    }

}
