using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.Factories;

internal class ReserveringFactory
{
    internal static Reservering CreateNewReseveringen(Klant klant, Vestiging luchthaven, Auto auto
    , DateTime startHuurPeriode, DateTime eindeHuurPeriode)
    {
        return new Reservering(Guid.NewGuid(), klant, luchthaven, auto, startHuurPeriode, eindeHuurPeriode);
    }
}
