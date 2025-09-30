using CadeaubonProject.Domein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadeaubonProject.Domein.Factories
{
    internal class CadeaubonFactory
    {
        internal static Cadeaubon CreateNewCadeaubon(Guid id, decimal saldo, ThemaType thematype, DateTime datum)
        {
            return new Cadeaubon(id, saldo, thematype, datum);
        }
    }
}
