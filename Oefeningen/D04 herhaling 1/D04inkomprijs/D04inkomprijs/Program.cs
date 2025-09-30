namespace D04inkomprijs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef uw lengte (in cm) in: ");
            int lengte = int.Parse(Console.ReadLine());

            Console.Write("Geef uw leeftijd in: ");
            int leeftijd = int.Parse(Console.ReadLine());

            double inkomPrijs = 10.0;

            if (lengte < 160 && leeftijd > 20)
            {
                inkomPrijs = inkomPrijs / 2;
            }

            Console.WriteLine($"Jouw inkomprijs bedraagt: {inkomPrijs} euro.");
        }
    }
}
