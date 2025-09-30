namespace D15immutablecirkelProject.Domein
{
    public class Cirkel
    {

       
        public double Straal { get; }

        public double Oppvervlakte()
        {
            return Straal * Straal * Math.PI;
        }

        public double Omtrekt()
        {
            return Straal * 2 * Math.PI;    
        }

        public Cirkel(double straal)
        {
            this.Straal = straal;
        }
    }
}
