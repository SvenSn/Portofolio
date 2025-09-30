using AutoVerhuurProject.Domein.DTOs;

namespace AutoVerhuurProject.Domein.Interfaces;

public interface IKlantRepositoryRead
{
    IEnumerable<KlantDTO> GetAll();

    KlantDTO? GetByEmail(string email);

    IEnumerable<KlantDTO> GetByName(string naam);

}
