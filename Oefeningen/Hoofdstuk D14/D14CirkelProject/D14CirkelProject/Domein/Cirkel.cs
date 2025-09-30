using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14CirkelProject.Domein
{
    public class Cirkel
    {
		private double _straal;

		public double Straal
		{
			get { return _straal; }
			set { _straal = value; }
		}

        public double Oppervlakte()
        {
            return (_straal*_straal) *Math.PI;
        }

        public double Omtrek()
        {
            return (_straal*2) * Math.PI;
        }

        public Cirkel(double straal)
        {
            _straal= straal;
        }
    }
}
