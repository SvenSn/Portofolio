using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.DTOs
{
    public record CadeaubonGebruikDTO (string WinkelNaam, DateTime Datum, decimal Waarde);
}
