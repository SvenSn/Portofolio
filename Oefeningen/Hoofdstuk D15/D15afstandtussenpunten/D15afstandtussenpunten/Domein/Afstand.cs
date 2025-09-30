namespace D15afstandtussenpunten.Domein
{
    public class Afstand
    {
        public double X { get; }
        public double Y { get; }    

        public static double GetAfstandTussen(Afstand a1,Afstand a2)
        {
            double x1 = a1.X;
            double x2 = a2.X;
            double y1 = a1.Y;
            double y2 = a2.Y;

            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public Afstand(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
