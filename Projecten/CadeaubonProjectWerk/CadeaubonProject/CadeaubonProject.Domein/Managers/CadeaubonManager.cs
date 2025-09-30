using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Factories;
using CadeaubonProject.Domein.Interfaces;
using CadeaubonProject.Domein.Models;

namespace CadeaubonProject.Domein.Managers;

public class CadeaubonManager : ICadeaubonManager
{
    private readonly ICadeaubonRepository _cadeaubonRepository;

    public CadeaubonManager(ICadeaubonRepository cadeaubonRepository)
    {
        if (cadeaubonRepository == null)
        {
            throw new ArgumentNullException("Repository mag niet leeg zijn.");
        } else
        {
            _cadeaubonRepository = cadeaubonRepository;
        }
    }

    public void VoegCadeaubonToe(Guid cadeaubonId, decimal waarde, ThemaType thematype, DateTime vervaldatum)
    {
        Cadeaubon cadeaubon = CadeaubonFactory.CreateNewCadeaubon(cadeaubonId, waarde, thematype, vervaldatum);

        CadeaubonDTO cadeaubonDTO = CadeaubonToCadeaubonDTOFactory.ConvertCadeaubonToCadeaubonDTO(cadeaubon);

        _cadeaubonRepository.Add(cadeaubonDTO);
    }

    public void VerwijderCadeaubon(Guid cadeaubonId)
    {
        _cadeaubonRepository.Delete(cadeaubonId);
    }


    public CadeaubonDTO GeefCadeaubon(Guid id)
    {
       return _cadeaubonRepository.GetById(id);
    }

    public void UpdateCadeaubon(Guid id, decimal bedrag)
    {
        _cadeaubonRepository.Update(id, bedrag);
    }

    public void VoegCadeaubonGebruikToe(Guid id, string winkel, DateTime datum, decimal waarde)
    {
        _cadeaubonRepository.AddCadeaubonGebruik(id, winkel, datum, waarde);
    }

    public IEnumerable<CadeaubonGebruikDTO> GeefCadeaubonGebruik(Guid id)
    {
        return _cadeaubonRepository.GetCadeaubonGebruik(id);
    }
}
