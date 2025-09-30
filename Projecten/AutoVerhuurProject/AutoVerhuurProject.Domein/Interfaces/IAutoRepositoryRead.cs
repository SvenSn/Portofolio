using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Factories;

namespace AutoVerhuurProject.Domein.Interfaces;

public interface IAutoRepositoryRead
{
    IEnumerable<AutoDTO> GetAll();

    AutoDTO GetByNummerplaat(string nummerplaat);

    IEnumerable<AutoDTO> GetByVestiging(string luchthaven);

    void Update(AutoDTO auto, string luchthaven);


}
