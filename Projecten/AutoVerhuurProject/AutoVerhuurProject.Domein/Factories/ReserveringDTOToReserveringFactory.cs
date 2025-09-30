using AutoVerhuurProject.Domein.DTOs;
using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories;

internal class ReserveringDTOToReserveringFactory
{
    public static Reservering ConvertReserveringDTOToReservering(ReserveringDTO reserveringDTO)
    {
        return new Reservering
            (
            reserveringDTO.ReserveringId,
            KlantDTOToKlantFactory.ConvertKlantDTOToKlant(reserveringDTO.klantDTO),
            VestigingDTOToVestigingFactory.ConvertVestigingDTOToVestiging(reserveringDTO.vestigingDTO),
            AutoDTOtoAutoFactory.ConvertAutoDTOtoAuto(reserveringDTO.autoDTO),
            reserveringDTO.StartHuurPeriode,
            reserveringDTO.EindeHuurPeriode
            );
    }
}
