namespace WinkelKarproject.Domein
{
	internal class VoedingsProduct : Product
	{
		private Nutriscore _nutriscore;

		public Nutriscore Nutriscore
		{
			get { return _nutriscore; }
			set
			{
				if (Enum.IsDefined(value))
				{
					_nutriscore = value;
				}
			}
		}

		public VoedingsProduct(string omschrijving, decimal prijsperstuk, Nutriscore nutriscore) : base(omschrijving, prijsperstuk)
		{
			nutriscore = Nutriscore;
		}



		private int BepaalKortingsPercentage()
		{
			switch (Nutriscore)
			{
				case Nutriscore.A: return 30;
				case Nutriscore.B: return 25;
				case Nutriscore.C: return 15;
				case Nutriscore.D: return 5;
				default: return 0;
			}
		}
        public override decimal GeefMijPrijsMetKorting()
        {
            return (GeefPrijsZonderKorting()) * (1 - (decimal)BepaalKortingsPercentage());
		}

        public override string ToString()
        {
            return $"{base.ToString()} en dankzij nutriscore {Nutriscore} een kortingspercentage van {BepaalKortingsPercentage()} % .";
        }
    }
}
