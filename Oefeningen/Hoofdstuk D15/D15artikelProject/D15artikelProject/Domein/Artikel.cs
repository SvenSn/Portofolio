namespace D15artikelProject.Domein
{
    public class Artikel
    {
		private decimal _btwpercentage;

		public decimal BTWpercentage
		{
			get { return _btwpercentage; }
			set { _btwpercentage = value; }
		}

		private decimal _prijsEXBTW;

		public decimal PrijsExBTW
		{
			get { return _prijsEXBTW; }
			set { _prijsEXBTW = value; }
		}

        public Artikel()
        {
			_btwpercentage = 21;
        }

		public decimal PrijsIncBTW()
		{
			return PrijsExBTW * (1 + (BTWpercentage / 100));
		}
    }
}
