using D14artikel.Domein;

namespace D14artikel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Artikel a1 = new Artikel();
            a1.PrijsExBTW = 1000m;
            a1.BTW = 12m;


            Console.WriteLine($"artikel 1 met prijs {a1.PrijsExBTW} ex btw en {a1.BTW} btw wordt {a1.PrijsIncBTW()} met btw");
        }
    }
}
