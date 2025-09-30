using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories;

internal static class ReserveringToReserveringDTOFactory
{

    public static ReserveringDTO ConvertReserveringToReserveringDTO(Reservering reservering)
    {
        return new ReserveringDTO(
            reservering.ReserveringId,
            KlantToKlantDTOFactory.ConvertKlantToKlantDTO(reservering.KlantReservering),
            VestigingToVestigingDTO.ConvertVestigingToVestigingDTO(reservering.Luchthaven),
            AutoToAutoDTOFactory.ConvertAutoInAutoDTO(reservering.AutoR),
            reservering.StartHuurPeriode,
            reservering.EindeHuurPeriode
            );
    }

}
