namespace D15rekeningkantoor.Domein
{
    public class Kantoor
    {
		private Persoon _kantoorhouder;

		public Persoon Kantoorhouder
		{
			get { return _kantoorhouder; }
			set { _kantoorhouder = value; }
		}
		private Adres _adres1;

		public Adres Adres1
		{
			get { return _adres1; }
			set { _adres1 = value; }
		}

        public Kantoor(Persoon kantoorhouder, Adres adres1)
        {
            Kantoorhouder = kantoorhouder;
            Adres1 = adres1;
        }
    }
}
