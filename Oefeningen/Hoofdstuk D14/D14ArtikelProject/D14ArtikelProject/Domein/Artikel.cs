namespace D14ArtikelProject.Domein
{
    public class Artikel
    {
		private double _prijsExBTW;

		public double PrijsExBTW
		{
			get { return _prijsExBTW; }
			set { _prijsExBTW = value; }
		}

		private double _BTWPercentage;

		public double BTWPerentage
		{
			get { return _BTWPercentage; }
			set { _BTWPercentage = value; }
		}

		public double PrijsIncBTW()
		{
			return PrijsExBTW * (1 + (BTWPerentage / 100));
		}

		

        public Artikel(double prijsExBTW, int bTWPerentage)
        {
            PrijsExBTW= prijsExBTW;
            BTWPerentage = bTWPerentage;
        }

        public Artikel(double prijsExBTW) 
        {
			PrijsExBTW = prijsExBTW;
			BTWPerentage= 21;
        }
    }
}
