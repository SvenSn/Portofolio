namespace D14artikel.Domein
{
    public class Artikel
    {

		private decimal _prijsExBTW;

		public decimal PrijsExBTW
		{
			get { return _prijsExBTW; }
			set { _prijsExBTW = value; }
		}

		private decimal _btw = 21m;

		public decimal BTW
		{
			get { return _btw; }
			set { _btw = value; }
		}


		public decimal PrijsIncBTW()
		{
			return PrijsExBTW * (1 + BTW/100);
		}



	}
}
