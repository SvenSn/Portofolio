using System.Runtime.CompilerServices;

namespace D15getafstandtussenenoverlapt.Domein
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
            double afstand = MiddelPunt.AfstandTussen(punt);
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

        public bool Overlapt(Cirkel c)
        {
            double somStralen = this.Straal + c.Straal;
            double afstandMiddelpunten = this.MiddelPunt.AfstandTussen(c.MiddelPunt);


            return (afstandMiddelpunten <= somStralen);
        }

    }
}
