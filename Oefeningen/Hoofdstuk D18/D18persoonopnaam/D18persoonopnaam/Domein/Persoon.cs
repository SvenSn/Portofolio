namespace D18persoonopnaam.Domein
{
    public class Persoon
    {
		private string _naam;

		public string Naam
		{
			get { return _naam; }
			set { _naam = value; }
		}

		private int _leeftijd;

		public int Leeftijd
		{
			get { return _leeftijd; }
			set { _leeftijd = value; }
		}

        public Persoon(string naam, int leeftijd)
        {
            this.Naam = naam;
            this.Leeftijd = leeftijd;
        }
    }
}
