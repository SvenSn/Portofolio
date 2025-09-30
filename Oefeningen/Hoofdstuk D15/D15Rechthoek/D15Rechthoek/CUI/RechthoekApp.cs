using D15Rechthoek.Domein;

namespace D15Rechthoek.CUI
{
    public class RechthoekApp
    {
        public void Run()
        {
            Rechthoek r1 = new Rechthoek();
            r1.Hoogte = 4.1;
            r1.Breedte = 3.2;


            Rechthoek r2 = new Rechthoek();
            r2.Hoogte = 5.2;
            r2.Breedte = 3.0;

            PrintRechthoek(r1);
            PrintRechthoek(r2);
        }

        static void PrintRechthoek(Rechthoek r)
        {
            Console.WriteLine($"De rechthoek meet een breedte van {r.Breedte} en een hoogte van {r.Hoogte} heeft een oppvervlakte van {r.Oppervlakte()}");
        }
    }
}
