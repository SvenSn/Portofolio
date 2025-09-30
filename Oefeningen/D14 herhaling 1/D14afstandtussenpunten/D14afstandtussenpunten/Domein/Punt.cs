namespace D14afstandtussenpunten.Domein
{
    public class Punt
    {
		private double _puntX;

		public double PuntX
		{
			get { return _puntX; }
			set { _puntX = value; }
		}

		private double _puntY;

		public double PuntY
		{
			get { return _puntY; }
			set { _puntY = value; }
		}

        public static double AfstandTussen(Punt p1, Punt p2)
        {
            double x1 = p1.PuntX;
            double x2 = p2.PuntX;
            double y1 = p1.PuntY;
            double y2 = p2.PuntY;

            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }


    }
}
