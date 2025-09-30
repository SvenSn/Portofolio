using D14cirkel.Domein;

namespace D14cirkel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Cirkel c = new Cirkel();

            c.Straal = 3.45;


            Console.WriteLine($"De cirkel met straal {c.Straal} heeft een omtrek van {c.Omtrek()} en een oppervlakte van {c.Oppervlakte()}");
        }
    }
}
