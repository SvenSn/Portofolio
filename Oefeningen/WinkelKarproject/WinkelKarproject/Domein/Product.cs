namespace WinkelKarproject.Domein
{
    public abstract class Product : IComparable<Product>
    {
		private string _omschrijving;

		public string Omschrijving
		{
			get { return _omschrijving; }
			init
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new ArgumentNullException(nameof(Omschrijving),"Omschrijving mag niet leeg of null zijn.");
				}
				_omschrijving = value;
			}
		}

		private decimal _prijsPerStuk;

		public decimal PrijsPerStuk
		{
			get { return _prijsPerStuk; }
			set 
			{
				if (value < 0)
				{
					throw new ArgumentException(nameof(PrijsPerStuk), "De prijs per stuk moet een positief getal zijn!");
				}
				_prijsPerStuk = value; 
			}
		}

		public Product (string omschrijving , decimal prijsPerStuk)
		{
			omschrijving = Omschrijving;
			prijsPerStuk = PrijsPerStuk ;
		}

		public decimal GeefPrijsZonderKorting()
		{
			return PrijsPerStuk;
		}

		public abstract decimal GeefMijPrijsMetKorting();

        public int CompareTo(Product p)
        {
            return Omschrijving.CompareTo(p.Omschrijving);
        }

        public virtual string ToString()
		{
			return $"{GetType().Name} {Omschrijving} aan {PrijsPerStuk} euro";
		}


	}
}
