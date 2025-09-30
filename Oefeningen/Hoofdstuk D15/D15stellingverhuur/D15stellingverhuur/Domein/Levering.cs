namespace D15stellingverhuur.Domein
{
    public class Levering
    {
		private string _adres;

		public string Adres
		{
			get { return _adres; }
			set { _adres = value; }
		}
		private int _afstandinkm;

		public int AfstandInKm
		{
			get { return _afstandinkm; }
			set { _afstandinkm = value; }
		}

        public Levering(string adres, int afstandInKm)
        {
            Adres = adres;
            AfstandInKm = afstandInKm;
        }
    }
}
