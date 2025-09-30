namespace D14afstandtussenpunten.Domein
{
	public class Punt
	{
		private double _x;

		public double X
		{
			get { return _x; }
			set { _x = value; }
		}

		private double _y;

		public double Y
		{
			get { return _y; }
			set { _y = value; }
		}

		public static double AfstandTussen(Punt p1, Punt p2)
		{
			double x1 = p1.X;
			double x2 = p2.X;
			double y1 = p1.Y;
			double y2 = p2.Y;

			return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
		}

        public Punt(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
