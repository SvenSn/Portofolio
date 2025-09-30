namespace D15stellingverhuur.Domein
{
    public class Periode
    {
		private DateTime _start;

		public DateTime Start
		{
			get { return _start; }
			set { _start = value; }
		}

		private DateTime _eind;

		public DateTime Eind
		{
			get { return _eind; }
			set { _eind = value; }
		}

		public int AantalUur()
		{
			TimeSpan duur = Eind - Start;
			double uren = duur.TotalHours;

			return (int)Math.Ceiling(uren);


		}

        public Periode(DateTime start, DateTime eind)
        {
            Start = start;
            Eind = eind;
        }

        



    }
}
