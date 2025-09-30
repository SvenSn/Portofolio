using D18persoonopnaamslim.Domein;

namespace D18persoonopnaamslim.CUI
{
    public class PersoonApp
    {
        public void Run()
        {
            List<Persoon> personen = new List<Persoon>();
            personen.Add(new Persoon("Jan", 23));
            personen.Add(new Persoon("Miet", 45));
            personen.Add(new Persoon("Joris", 34));
            personen.Add(new Persoon("Corneel", 12));
            personen.Add(new Persoon("Phara", 34));

            PrintPersonenMetTitel("ongesorteerd", personen);

            PersoonNaamComparerSlim pncs = new PersoonNaamComparerSlim(true);
            personen.Sort(pncs);

            PrintPersonenMetTitel("Gesorteerd op naam a->z", personen);

            PersoonNaamComparerSlim pncs2 = new PersoonNaamComparerSlim(false);
            personen.Sort(pncs2);
            PrintPersonenMetTitel("gesorteerd op naam z->a", personen);







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
