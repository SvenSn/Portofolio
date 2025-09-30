namespace D08Netto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] kortingen = { 10, 50, 19.4 };
            double brutoBedrag = 1000;

            double nettoBedrag = brutoBedrag;
            foreach (double netto in kortingen)
            {
                nettoBedrag -= netto;
            }

            Console.Write("Netto bedrag: " + nettoBedrag);
        }
    }
}
