using D14persoonProject.Domein;

namespace D14persoonProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime d1 = new DateTime(2000, 5, 1);
            DateTime d2 = new DateTime(2000, 6, 1);

            Persoon p1 = new Persoon();
            p1.SetGeboortedatum(d1);
            p1.SetNaam("Liam");
            p1.Woonplaats = "Laarne";

            Persoon p2 = new Persoon();
            p2.SetGeboortedatum(d2);
            p2.SetNaam("Liam");
            p2.Woonplaats = "wetteren";

            PrintPersoonsgegevens(p1);
            PrintPersoonsgegevens(p2);

        }
        static void PrintPersoonsgegevens(Persoon persoon)
        {
            Console.WriteLine(persoon.GetNaam());
            Console.WriteLine(persoon.Woonplaats);
            Console.WriteLine(persoon.Leeftijd());
        }
    }

  
}
