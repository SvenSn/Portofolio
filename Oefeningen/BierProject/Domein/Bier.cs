using System.Collections.Generic;

namespace Domein
{
	public class Bier
	{
		public Bier(string naam, string soort, double alcoholgehalte, double beoordeling, string brouwerij)
		{
			Naam = naam;
			Soort = soort;
			Brouwerij = brouwerij;
			Alcoholgehalte = alcoholgehalte;
			Beoordeling = beoordeling;
		}

		public string Naam { get; set; }
		public string Soort { get; set; }
		public string Brouwerij { get; set; }
		public double Alcoholgehalte { get; set; }
		public double Beoordeling { get; set; }

		public override string ToString()
		{
			return string.Format($"naam = {Naam}, soort = {Soort}, brouwerij = {Brouwerij}, " +
				$"alcoholgehalte = {Alcoholgehalte:F2}, beoordeling = {Beoordeling:F1}");
		}
    }
}