using D15cirkeloverlapt.Domein;

namespace D15cirkeloverlapt.CUI
{
    public class CirkelApp
    {
        public void Run()
        {
            Cirkel c1 = new Cirkel(10, 20, 5);
            Cirkel c2 = new Cirkel(8, 12, 10);
            Cirkel c3 = new Cirkel(100, 200, 3);
            Cirkel c4 = new Cirkel(100, 80, 200);

            Console.WriteLine(Cirkel.Overlapt(c1, c2));  // moet true opleveren
            Console.WriteLine(Cirkel.Overlapt(c2, c3));  // moet false opleveren
            Console.WriteLine(Cirkel.Overlapt(c3, c4)); // zou true moeten zijn
        }
    }
}
