using D15Figuren.Figuren;

namespace D15Figuren.CUI
{
    public class FigurenApp
    {
        public void Run()
        {
            Cirkel c1 = new Cirkel(10, 20, 5);
            Cirkel c2 = new Cirkel(8, 12, 10);
            Cirkel c3 = new Cirkel(100, 200, 3);

            Console.WriteLine(Cirkel.Overlapt(c1, c2));  // moet true opleveren
            Console.WriteLine(Cirkel.Overlapt(c2, c3));  // moet false opleveren
        }
    }
}
