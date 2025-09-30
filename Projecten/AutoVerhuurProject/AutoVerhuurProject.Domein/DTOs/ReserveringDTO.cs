using AutoVerhuurProject.Domein.Models;

namespace AutoVerhuurProject.Domein.DTOs;

public record ReserveringDTO
    (Guid ReserveringId,
    KlantDTO klantDTO,
    VestigingDTO vestigingDTO,
    AutoDTO autoDTO,
    DateTime StartHuurPeriode,
    DateTime EindeHuurPeriode);


