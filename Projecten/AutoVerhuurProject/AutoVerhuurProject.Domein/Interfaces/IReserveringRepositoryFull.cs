using AutoVerhuurProject.Domein.DTOs;
using System.Collections.ObjectModel;

namespace AutoVerhuurProject.Domein.Interfaces;

public  interface IReserveringRepositoryFull
{
    IEnumerable<ReserveringDTO> GetAllReserveringen();

    void Add(ReserveringDTO reservering);

    void Delete(Guid id);

    bool IsAutoBeschikbaar(string nummerplaat, DateTime startdatum, DateTime einddatum);
}
