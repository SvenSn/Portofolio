using CadeaubonProject.Domein.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Interfaces
{
    public interface ICadeaubonManager
    {
        void VoegCadeaubonToe(Guid cadeaubonId, decimal waarde, ThemaType thematype, DateTime vervaldatum);
        void VerwijderCadeaubon(Guid cadeaubonId);
        CadeaubonDTO GeefCadeaubon(Guid id);
        void UpdateCadeaubon(Guid id, decimal bedrag);
        void VoegCadeaubonGebruikToe(Guid id, string winkel, DateTime datum, decimal waarde);
        IEnumerable<CadeaubonGebruikDTO> GeefCadeaubonGebruik(Guid id);
    }
}
