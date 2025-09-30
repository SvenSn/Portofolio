using D18factuur.Domein;

namespace D18factuur.CUI
{
    public class FactuurApp
    {
        public void Run()
        {
            
            Factuur f1 = new Factuur(200, new DateTime(2021, 1, 6));
            Factuur f2 = new Factuur(100, new DateTime(2020, 1, 6));
            Factuur f3 = new Factuur(400, new DateTime(2019, 1, 6));
            Factuur f4 = new Factuur(300, new DateTime(2019, 1, 6));

            // Het bedrag en de vervaldatum zijn verder (na creatie) niet meer
            // aan te passen, uiteraard wel op te vragen...
            Console.WriteLine($"Bedrag factuur f4: {f4.Bedrag}");            // 300
            Console.WriteLine($"Vervaldatum factuur f4: {f4.VervalDatum}");  // 6/01/2019 0:00:00
            Console.WriteLine();
            //f4.Bedrag = 401;                           // zou een compilefout moeten opleveren
            //f4.Vervaldatum = new DateTime(2020, 1, 6); // zou een compilefout moeten opleveren

            // Wel kan men instellen of de factuur al dan niet betaald is...
            f4.IsBetaald = true;

            // By default zijn facturen nog niet betaald...
            Console.WriteLine($"Factuur f3 is betaald: {f3.IsBetaald}");    // False
            Console.WriteLine($"Factuur f4 is betaald: {f4.IsBetaald}");    // True
            Console.WriteLine();

            // Er kan worden nagegaan of een factuur achterstallig is op een bepaalde datum (de parameterwaarde).
            DateTime dt = new DateTime(2020, 1, 6);
            Console.WriteLine($"Factuur f1 is achterstallig: {f1.IsAchterStallig(dt)}");   // False
            Console.WriteLine($"Factuur f2 is achterstallig: {f2.IsAchterStallig(dt)}");   // False
            Console.WriteLine($"Factuur f3 is achterstallig: {f3.IsAchterStallig(dt)}");   // True
            Console.WriteLine($"Factuur f4 is achterstallig: {f4.IsAchterStallig(dt)}");   // False
            Console.WriteLine();

            // Alle aparte factuur objecten worden aan een lijst toegevoegd...
            List<Factuur> facturen = new List<Factuur>() { f1, f2, f3, f4 };

            // De lijst wordt afgedrukt...
            Console.WriteLine("Ongesorteerd");
            PrintFacturen(facturen);

            // De lijst wordt gesorteerd op bedag, van groot naar klein, en opnieuw afgedrukt...
            facturen.Sort(new FactuurBedragComparer());
            Console.WriteLine("Gesorteerd");
            PrintFacturen(facturen);
        }

        static void PrintFacturen(List<Factuur> facturen)
        {
            foreach (Factuur f in facturen)
            {
                PrintFactuurDetails(f);
            }
            Console.WriteLine();
        }

        static void PrintFactuurDetails(Factuur f)
        {
            // TODO : deze method moet je zelf schrijven
            if (f.IsBetaald == false)
            {
                Console.WriteLine($"Factuur voor een bedrag {f.Bedrag} met een vervaldatum {f.VervalDatum}.");
            }
            else if (f.IsBetaald == true)
            {
                Console.WriteLine($"Factuur voor een bedrag {f.Bedrag} (betaald).");
            }
            

        }
    
    }
}
