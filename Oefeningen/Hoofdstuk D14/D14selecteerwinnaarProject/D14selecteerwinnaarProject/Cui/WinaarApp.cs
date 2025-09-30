using D14selecteerwinnaarProject.Domein;

namespace D14selecteerwinnaarProject.Cui
{
    public class WinaarApp
    {
        public void Run()
        {
            Persoon[] personen = new Persoon[5];

            personen[0] = new Persoon();
            personen[0].SetNaam("Sven");

            personen[1] = new Persoon();
            personen[1].SetNaam("Liam");

            personen[2] = new Persoon();
            personen[2].SetNaam("Rudy");

            personen[3] = new Persoon();
            personen[3].SetNaam("Dusty");

            personen[4] = new Persoon();
            personen[4].SetNaam("Tiger");

            

            Persoon Winnaar = SelectWinnaar(personen);

            Console.WriteLine($"De winnaar is {Winnaar.GetNaam()}");
        }

        static Persoon SelectWinnaar(Persoon[] kansMakers)
        {
            Random r = new Random();
            int nummer = r.Next(kansMakers.Length);
            return kansMakers[nummer];
        }
    }
}
