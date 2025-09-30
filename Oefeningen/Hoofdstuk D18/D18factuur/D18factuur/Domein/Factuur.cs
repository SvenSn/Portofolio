namespace D18factuur.Domein
{
    public class Factuur
    {
		private bool _isBetaald;

		public bool IsBetaald
		{
			get { return _isBetaald; }
			set { _isBetaald = value; }
		}

		private DateTime _vervalDatum;

		public DateTime VervalDatum
		{
			get { return _vervalDatum; }
			private set { _vervalDatum = value; }
		}

		private decimal _bedrag;

		public decimal Bedrag
		{
			get { return _bedrag; }
			private set { _bedrag = value; }
		}

		public bool IsAchterStallig(DateTime datum)
		{
			bool achterstallig;

			if (_isBetaald == false && VervalDatum < datum)
			{
				achterstallig = true;
			}else
			{
				achterstallig = false;
			}

			return achterstallig;
		}

        public Factuur(decimal bedrag , DateTime vervalDatum)
        {
            VervalDatum = vervalDatum;
            Bedrag = bedrag;
        }
    }
}
