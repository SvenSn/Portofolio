using AutoVerhuurProject.Domein.DTOs;

namespace AutoVerhuurProject.Domein.Interfaces;

public interface IVestigingRepositoryRead
{
    List<VestigingDTO> GetAll();

    VestigingDTO? GetByName();

    VestigingDTO? GetByAuto();
}
