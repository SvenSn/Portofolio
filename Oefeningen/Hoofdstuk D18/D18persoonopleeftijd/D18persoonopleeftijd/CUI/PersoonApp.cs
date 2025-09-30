using D18persoonopleeftijd.Domein;

namespace D18persoonopleeftijd.CUI
{
    public class PersoonApp
    {
        public void Run()
        {
            List<Persoon> personen = new List<Persoon>();
            personen.Add(new Persoon("Jan",23));
            personen.Add(new Persoon("Miet", 45));
            personen.Add(new Persoon("Joris", 34));
            personen.Add(new Persoon("Corneel", 12));
            personen.Add(new Persoon("Phara", 34));

            PrintPersonenMetTitel("ongesorteerd", personen);

            PersoonLeeftijdCompare plc = new PersoonLeeftijdCompare();
            personen.Sort(plc);

            PrintPersonenMetTitel("Gesorteerd op leeftijd", personen);




            static void PrintPersonenMetTitel(string titel, List<Persoon> personen)
            {
                Console.WriteLine($"--- {titel} ---");

                // Toon alle personen op de console 
                foreach (Persoon p in personen)
                {
                    Console.WriteLine($"{p.Naam}, {p.Leeftijd} Jaar");
                }
            }
        }
    }
}
