namespace CadeaubonProject.Domein.DTOs;

public record BestellingDTO(Guid AankoopId, string Beschrijving, KlantDTO klantDTO, CadeaubonDTO cadeaubonDTO);

