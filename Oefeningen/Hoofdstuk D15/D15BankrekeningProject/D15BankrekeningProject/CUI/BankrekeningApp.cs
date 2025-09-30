using D15BankrekeningProject.Domein;

namespace D15BankrekeningProject.CUI
{
    public class BankrekeningApp
    {
        public void Run()
        {
            Bankrekening b1 = new Bankrekening();
            Bankrekening b2 = new Bankrekening();


            decimal bedrag = 100m;

            b1.Overschrijven(bedrag, b2);

            Console.WriteLine(b1.Saldo == -100m);
            Console.WriteLine(b2.Saldo == 100m);
        }
    }
}
