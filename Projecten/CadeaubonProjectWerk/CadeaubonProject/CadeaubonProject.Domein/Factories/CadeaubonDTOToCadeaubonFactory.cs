using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Factories
{
    internal class CadeaubonDTOToCadeaubonFactory
    {
        public static Cadeaubon ConvertCadeaubonDTOToCadeaubon(CadeaubonDTO cadeaubonDTO)
        {
            return new Cadeaubon(
                cadeaubonDTO.Id,
                cadeaubonDTO.Saldo,
                (ThemaType) cadeaubonDTO.Thematype,
                cadeaubonDTO.Datum);

        }
    }
}
