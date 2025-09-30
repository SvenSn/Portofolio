using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.DTOs;

public record KlantDTO(Guid KlantId, string Email, string Passwoord, string Voornaam, string Achternaam);


