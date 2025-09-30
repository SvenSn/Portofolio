namespace D15getafstandtussenenoverlapt.Domein
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

        public double AfstandTussen(Punt p)
        {
            double x1 = this.X;
            double x2 = p.X;
            double y1 = this.Y;
            double y2 = p.Y;

            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public Punt(double x, double y)
        {
            X = x;
            Y = y;
        }

    }
}
