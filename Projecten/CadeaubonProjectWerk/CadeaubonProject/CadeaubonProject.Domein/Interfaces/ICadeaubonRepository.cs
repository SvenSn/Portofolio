using CadeaubonProject.Domein.DTOs;

namespace CadeaubonProject.Domein.Interfaces;

public interface ICadeaubonRepository
{
    void Add(CadeaubonDTO cadeaubon);
    void Delete(Guid id);
    IEnumerable<CadeaubonDTO> GetAll();
    void Update(Guid id, decimal bedrag);
    void AddCadeaubonGebruik(Guid id, string winkel, DateTime datum, decimal waarde);
    IEnumerable<CadeaubonGebruikDTO> GetCadeaubonGebruik(Guid id);
    CadeaubonDTO GetById(Guid id);
    




}
