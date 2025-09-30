using Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class AutoRepository : IAutoRepository
    {
        private AutoMapper _autoMapper = new AutoMapper();

        public List<Auto> GeefAutos() => _autoMapper.GeefAutos();
    }
}
