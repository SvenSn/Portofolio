using D15PersoonProject.Domein;

namespace D15PersoonProject.CUI
{
    public class PersoonApp
    {
        public void Run()
        {
            DateTime gb1 = new DateTime(1997, 07, 08);
            DateTime gb2 = new DateTime(2008, 03, 30);
            DateTime gb3 = new DateTime(1974, 07, 08);

            Persoon p1 = new Persoon();
            p1.Naam = "Sven";
            p1.Woonplaats = "Laarne";
            p1.Geboortedatum = gb1;

            PrintPersoonGegevens(p1);

            Persoon p2 = new Persoon();
            p2.Naam = "Liam";
            p2.Woonplaats = "Laarne";
            p2.Geboortedatum = gb2;

            PrintPersoonGegevens(p2);

            Persoon p3 = new Persoon();
            p3.Naam = "Dusty";
            p3.Woonplaats = "Laarne";
            p3.Geboortedatum = gb3;

            PrintPersoonGegevens(p3);

        }

        static void PrintPersoonGegevens(Persoon persoon)
        {
            Console.WriteLine(persoon.Naam);
            Console.WriteLine(persoon.Woonplaats);
            Console.WriteLine(persoon.Leeftijd());
        }
    }
}
