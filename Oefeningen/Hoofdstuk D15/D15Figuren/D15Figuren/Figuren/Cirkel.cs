namespace D15Figuren.Figuren
{
    public class Cirkel
    {
        public double Straal { get; }

        public Punt MiddelPunt { get; private set; }

        public void VerplaatsNaar(double x, double y)
        {
            MiddelPunt = new Punt(x, y);
        }

        public bool Bevat(Punt punt)
        {
            double afstand = Punt.AfstandTussen(MiddelPunt, punt);
            return (afstand <= Straal);
        }

        public double Oppervlakte()
        {
            return Straal * Straal * Math.PI;

        }

        public double Omtrekt()
        {
            return Straal * 2 * Math.PI;
        }

        public Cirkel(double straal) : this(0, 0, straal)
        {

        }

        public Cirkel(int x, int y, double straal)
        {
            this.MiddelPunt = new Punt(x, y);
            this.Straal = straal;
        }

        public static bool Overlapt(Cirkel c1, Cirkel c2)
        {
            double somStralen = c1.Straal + c2.Straal;
            double afstandMiddelpunten = Punt.AfstandTussen(c1.MiddelPunt, c2.MiddelPunt);


            return (afstandMiddelpunten <= somStralen);
        }
    }
}
