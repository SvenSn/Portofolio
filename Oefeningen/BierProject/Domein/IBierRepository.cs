using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public interface IBierRepository
    {
        List<Bier> GeefBieren();
    }
}
