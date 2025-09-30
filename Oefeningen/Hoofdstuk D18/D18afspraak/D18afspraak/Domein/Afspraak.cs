namespace D18afspraak.Domein
{
    public class Afspraak
    {
		private DateTime _start;

		public DateTime Start
		{
			get { return _start; }
			private set { _start = value; }
		}

		private DateTime _einde;

		public DateTime Einde
		{
			get { return _einde; }
			private set { _einde = value; }
		}

		private string _omschrijving;

		public string Omschrijving
		{
			get { return _omschrijving; }
			private set { _omschrijving = value; }
		}

		public bool Overlapt(Afspraak a)
		{
			return Einde > a.Start && Start < a.Einde;
		}
		private int _duur;

		public int Duur
		{
			get { return (int)(Einde - Start).TotalMinutes; }
			set { _duur = value; }
		}


		public Afspraak(DateTime start, DateTime einde, string omschrijving)
        {
            Start = start;
            Einde = einde;
            Omschrijving = omschrijving;
        }
    }
}
