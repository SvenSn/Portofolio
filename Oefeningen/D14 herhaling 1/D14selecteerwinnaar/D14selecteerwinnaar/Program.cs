using D14selecteerwinnaar.Domein;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;

namespace D14selecteerwinnaar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persoon[] personen = new Persoon[5];

            personen[0] = new Persoon(); personen[0].SetNaam("Liam");
            personen[1] = new Persoon(); personen[1].SetNaam("Sven");
            personen[2] = new Persoon(); personen[2].SetNaam("Dusty");
            personen[3] = new Persoon(); personen[3].SetNaam("Rudy");
            personen[4] = new Persoon(); personen[4].SetNaam("Britt");


            Persoon winnaar = SelecteerWinnaar(personen);

            Console.WriteLine($"De winnaar is {winnaar.GetNaam()}");    
        }

        private static Persoon SelecteerWinnaar(Persoon[] personen)
        {
            Random r = new Random();    
            int index = r.Next(personen.Length);
            return personen[index];
        }
    }
}
