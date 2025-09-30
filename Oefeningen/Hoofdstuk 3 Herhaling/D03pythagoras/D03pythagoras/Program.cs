namespace D03pythagoras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef de basis. ");
            string basisText = Console.ReadLine();
            double basis = double.Parse(basisText);

            Console.Write("Geef de hoogte. ");
            string hoogteText = Console.ReadLine();
            double hoogte = double.Parse(hoogteText);

            double lengteSchuineZijde = Math.Sqrt(Math.Pow(basis,2)+Math.Pow(hoogte,2));

            Console.WriteLine($"De lengte van de schuine zijde is: {lengteSchuineZijde}");


        }
    }
}
