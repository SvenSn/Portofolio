using static AutoVerhuurProject.Domein.Models.Auto;

namespace AutoVerhuurProject.Domein.DTOs;

public record AutoDTO(string Nummerplaat, string Model, int Zitplaatsen, string MotorType);


