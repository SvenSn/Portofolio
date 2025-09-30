using D14CirkelProject.Domein;

namespace D14CirkelProject.Cui
{
    public class CirkelApp
    {
        public void Run()
        {
            Cirkel c1 = new Cirkel(5.6);

            Console.WriteLine($"De straal is {c1.Straal}, de oppervlakte is: {c1.Oppervlakte()} en de omtrek is: {c1.Omtrek()}");
        }
    }
}
