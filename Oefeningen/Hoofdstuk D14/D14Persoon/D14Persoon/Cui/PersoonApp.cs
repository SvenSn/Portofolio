
using D14Persoon.Domein;

namespace D14Persoon.Cui
{
    public class PersoonApp
    {
        public void Run()
        {
            DateTime Geb1 = new DateTime(1997,07,08);
            DateTime Geb2 = new DateTime(2008,06,30);
            DateTime Geb3 = new DateTime(2002, 02, 01);
        

            Persoon p1 = new Persoon();
            p1.SetNaam("Sven");
            p1.SetGeboortedatum(Geb1);
            p1.SetWoonplaats("Laarne");
            PrintPersoon(p1);



            Persoon p2 = new Persoon();
            p2.SetNaam("Liam");
            p2.SetGeboortedatum(Geb2);
            p2.SetWoonplaats("Laarne");
            PrintPersoon(p2);


        }
        static void PrintPersoon(Persoon persoon)
        {
            Console.WriteLine(persoon.GetNaam());
            Console.WriteLine(persoon.GetWoonplaats());
            Console.WriteLine(persoon.Leeftijd());
        }

    }
}
