using CadeaubonProject.Domein.DTOs;
using Microsoft.VisualBasic.FileIO;

namespace CadeaubonProject.Domein.Interfaces;

 public interface IKlantRepository
{
    IEnumerable<KlantDTO> GetAll();

    void Add(KlantDTO klantDTO);

    KlantDTO? GetByEmail(string email);
    KlantDTO? GetById(Guid klantId);
    void Delete(Guid id);

    void Update(Guid id);
}
