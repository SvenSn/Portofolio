using System.Xml.Serialization;

namespace D03_pythagoras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de lengte van de schuine zijde berekent van een rechthoekige driehoek.
            //Het programma vraagt de gebruiker om de basis en de hoogte van de driehoek(beiden kommagetallen) en toont dan de lengte van de schuine zijde.


            Console.WriteLine("Geef de basis van de driehoek in.");
            double basis = double.Parse(Console.ReadLine());

            Console.WriteLine("Geef de hoogte van de driehoek in.");
            double hoogte = double.Parse(Console.ReadLine());

            double schuineZijde = Math.Sqrt(Math.Pow(basis, 2) + Math.Pow(hoogte, 2));

            Console.WriteLine($"De schuine zijde van de rechthoekige driehoek is {schuineZijde}");
        }
    }
}
