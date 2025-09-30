using D14rechthoek.Domein;

namespace D14rechthoek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rechthoek rechthoek1 = new Rechthoek();
            rechthoek1.Hoogte = 4.1;
            rechthoek1.Breedte = 8;

            Rechthoek rechthoek2 = new Rechthoek();
            rechthoek2.Hoogte = 5;
            rechthoek2.Breedte = 10.2;

            PrintRechthoek(rechthoek1);
            PrintRechthoek(rechthoek2);
        }
        static void PrintRechthoek(Rechthoek r)
        {
            Console.WriteLine($"Rechthoek met hoogte {r.Hoogte}, breedte {r.Breedte} en oppervlakte {r.Oppervlakte()}.");
        }
    }
}
