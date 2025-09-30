namespace D15stellingverhuur.Domein
{
    public class StellingVerhuring
    {
		private DateTime _startVerhuur;

		public DateTime StartVerhuur
		{
			get { return _startVerhuur; }
			set { _startVerhuur = value; }
		}

		private DateTime _eindVerhuur;

		public DateTime EindVerhuur
		{
			get { return _eindVerhuur; }
			set { _eindVerhuur = value; }
		}
		private int _aantalUurOpbouw;

		public int AantalUurOpbouw
		{
			get { return _aantalUurOpbouw; }
			set { _aantalUurOpbouw = value; }
		}
		private int _aantalUurAfbraak;

		public int AantalUurAfbraak
		{
			get { return _aantalUurAfbraak; }
			set { _aantalUurAfbraak = value; }
		}

        public StellingVerhuring(DateTime startVerhuur, DateTime eindVerhuur)
        {
            StartVerhuur = startVerhuur;
            EindVerhuur = eindVerhuur;
			AantalUurOpbouw = 8;
			_aantalUurAfbraak = 4;
        }

		

		private Levering _levering;

		public Levering Levering
		{
			get { return _levering; }
			set { _levering = value; }
		}



		public Periode NettoVerhuurPeriode()
		{
			DateTime startTijdstip = StartVerhuur.AddHours(AantalUurOpbouw);
			DateTime eindTijdstip = EindVerhuur.AddHours(-AantalUurAfbraak);
            return new Periode(startTijdstip, eindTijdstip);

        }
        public decimal Prijs()
        {

            // De prijs van een StellingVerhuring kan worden opgevraagd...
            // De prijs wordt minimaal berekend op aantal...
            // . uren opbouw (90 per uur)         90 x   8 =  720
            // . netto uren verhuur (5 per uur)    5 x 741 = 3705
            // . uren afbraak (60 per uur)        60 x   4 =  240
			int uren = NettoVerhuurPeriode().AantalUur();
            decimal prijsOpbouw = 90 * AantalUurOpbouw;
			decimal prijsVerhuur = uren * 5;
			decimal prijsAfbraak = AantalUurAfbraak * 60;

			if (Levering != null)
			{
				decimal prijsLevering = Levering.AfstandInKm * 10;
                return prijsOpbouw + prijsVerhuur + prijsAfbraak+prijsLevering;
            }
			else
			{
                return prijsOpbouw + prijsVerhuur + prijsAfbraak;
            }

			
        }


    }
}
