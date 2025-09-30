using CadeaubonProject.Domein.DTOs;
using CadeaubonProject.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Factories
{
    internal class CadeaubonToCadeaubonDTOFactory
    {
        public static CadeaubonDTO ConvertCadeaubonToCadeaubonDTO(Cadeaubon cadeaubon)
        {
            return new CadeaubonDTO
                (cadeaubon.CadeaubonId,
                cadeaubon.Saldo,
                cadeaubon.Thema,
                cadeaubon.Datum
                );
        }
    }
}
