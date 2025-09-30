namespace D15PersoonProject.Domein
{
    public class Persoon
    {

        //Naam, Geboortedatum en `Woonplaats´.

        private string _naam;

		public string Naam
		{
			get { return _naam; }
			set { _naam = value; }
		}

		private DateTime _geboorteDatum;

		public DateTime Geboortedatum
		{
			get { return _geboorteDatum; }
			set { _geboorteDatum = value; }
		}

		private string _woonplaats;

		public string Woonplaats
		{
			get { return _woonplaats; }
			set { _woonplaats = value; }
		}

		public int Leeftijd()
		{
			int leeftijd = 0;
			DateTime dt = Geboortedatum.Date.AddYears(1);

			while (dt < DateTime.Today)
			{
				leeftijd++;
				dt = dt.AddYears(1);
			}

			return leeftijd;
		}

	}
}
