namespace D18interval.Domein
{
    public class Interval
    {
		private int _min;

		public int Min
		{
			get { return _min; }
			private set { _min = value; }
		}
		private int _max;

		public int Max
		{
			get { return _max; }
			private set { _max = value; }
		}

		public int Lengte
		{
			get { return Max - Min; }
		}



		public Interval(int min, int max)
        {
			if (min >= max)
			{
				throw new ArgumentException("De ondergrens moet kleiner zijn dan de bovengrens");
			}
            Min = min;
            Max = max;
			
			
        }

        public bool OverlaptMet(Interval a)
		{
			return Min < a.Max && Max > a.Min;
		}
	}
}
