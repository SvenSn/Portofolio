using D14bankrekening.Domein;

namespace D14bankrekening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bankrekening b1 = new Bankrekening();
            Bankrekening b2 = new Bankrekening();

            decimal bedrag = 100m;

            b1.SchrijfOver(bedrag, b2);

            Console.WriteLine(b1.Saldo() == -100m); // zou true moeten geven
            Console.WriteLine(b2.Saldo() == 100m);  // zou true moeten geven
        }
    }
}
