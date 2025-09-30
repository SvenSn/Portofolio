namespace D14uitlening.Domein
{
    public class Uitlening
    {
		private string _omschrijving;

		public string Omschrijving
		{
			get { return _omschrijving; }
			set { _omschrijving = value; }
		}

		private DateTime _ontleenDatum;

		public DateTime OntleenDatum
		{
			get { return _ontleenDatum; }
			set { _ontleenDatum = value; }
		}

		public DateTime UitersteInLeverdatum()
		{
			return OntleenDatum.AddDays(14);
		}

        public Uitlening(string omschrijving, DateTime ontleenDatum)
        {
            Omschrijving = omschrijving;
            OntleenDatum = ontleenDatum;
        }
    }
}
