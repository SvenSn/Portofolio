using D15CirkelProject.Domein;

namespace D15CirkelProject.CUI
{
    public class CirkelApp
    {
        public void Run()
        {

            Cirkel c1 = new Cirkel();
            c1.Straal = 5.2;

            Cirkel c2 = new Cirkel();
            c2.Straal = 3.1;

            PrintCirkel(c1);
            PrintCirkel(c2);
        }

        static void PrintCirkel(Cirkel c)
        {
            Console.WriteLine($" de straal is {c.Straal}");
            Console.WriteLine($"De oppervlakte van deze cirkel is {c.Oppervlakte()}");
            Console.WriteLine($"De omtrek van deze cirkel is {c.Omtrek()}");
        }
    }
}
