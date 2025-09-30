namespace D08_netto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pas volgende voorbeeld aan om met een foreach (in plaats van de for) elke waarde uit de kortingen array van het brutoBedrag af te trekken.


            double[] kortingen = { 10, 50, 19.4 };
            double brutoBedrag = 1000;

            double nettoBedrag = brutoBedrag;
            foreach (double i in kortingen)
            {
                nettoBedrag -= i;
            }

            Console.Write("Netto bedrag: " + nettoBedrag);

        }
    }
}
