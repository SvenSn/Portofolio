namespace D04oefeningprijsappels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("aantal kilo aan te kopen appels?: ");
            int aantalKilo = int.Parse(Console.ReadLine());

            double prijsPerKilo;

            if (aantalKilo >= 20)
            {
                prijsPerKilo = 2.0;
            }
            else if (aantalKilo >= 10)
            {
                prijsPerKilo = 2.5;
            }
            else
            {
                prijsPerKilo = 3.0;
            }

            double totalePrijs = aantalKilo * prijsPerKilo;

            Console.WriteLine($" Prijs: {totalePrijs} euro.");
        }
    }
}
