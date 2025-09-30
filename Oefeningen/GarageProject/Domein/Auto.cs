using System;
using System.Collections.Generic;

namespace Domein
{

	public class Auto : IComparable<Auto>
	{
		public Auto(string nummerplaat, string merk, string model)
		{
			Nummerplaat = nummerplaat;
			Merk = merk;
			Model = model;
		}

		public string Merk { get; set; }

		public string Model { get; set; }

		public string Nummerplaat { get; set; }

        public int CompareTo(Auto other)
        {
			int result = this.Merk.CompareTo(other.Merk);

			if (result != 0)
				return result;

			return this.Model.CompareTo(other.Model);
        }

        public class AutoComparer : IComparer<Auto>
        {
            public int Compare(Auto x, Auto other)
            {
				int result = x.Merk.CompareTo(other.Merk);

				if (result != 0)
					return result * -1;

				return x.Model.CompareTo(other.Model) * -1;
			}
        }

        public override bool Equals(object obj)
        {
            return obj is Auto auto &&
                   Nummerplaat == auto.Nummerplaat;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nummerplaat);
        }

        public override string ToString()
		{
			return string.Format("nummerplaat= {0}, merk= {1}, model = {2}", Nummerplaat, Merk, Model);
		}

		
	}

}