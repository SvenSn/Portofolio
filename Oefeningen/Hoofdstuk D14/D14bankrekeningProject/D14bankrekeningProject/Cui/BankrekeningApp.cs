using D14bankrekeningProject.Domein;

namespace D14bankrekeningProject.Cui
{
    public class BankrekeningApp
    {

        public void Run()
        {
            Bankrekening b1 = new Bankrekening();
            Bankrekening b2 = new Bankrekening();

            decimal bedrag = 100m;


            //bedrag overschrijven van b1 naar de doel rekening b2 
            b1.SchrijOver(bedrag,b2);

            Console.WriteLine(b1.Saldo() == -100m); // zou true moeten geven
            Console.WriteLine(b2.Saldo() == 100m);  // zou true moeten geven
        }
    }
}
