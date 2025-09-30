using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Interfaces;

namespace AutoVerhuurProject.Domein;

public class VestigingManager(IVestigingRepositoryRead vestigingRepositoryRead)
{
    private IVestigingRepositoryRead _vestigingRepositoryRead =
           vestigingRepositoryRead is null ?
           throw new ArgumentNullException("De reserveringrepository mag niet null zijn") :
           vestigingRepositoryRead;


    public IEnumerable<VestigingDTO> GeefAlleVestigingen()
    {
        return _vestigingRepositoryRead.GetAll();
    }
}
