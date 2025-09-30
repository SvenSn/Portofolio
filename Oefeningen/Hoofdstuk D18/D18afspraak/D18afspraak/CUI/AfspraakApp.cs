using D18afspraak.Domein;

namespace D18afspraak.CUI
{
    public class AfspraakApp
    {
        public void Run()
        {
            DateTime tijdstip1 = new DateTime(2021, 1, 20, 10, 00, 00);
            DateTime tijdstip2 = new DateTime(2021, 1, 20, 12, 30, 00);
            DateTime tijdstip3 = new DateTime(2021, 1, 20, 13, 30, 00);
            DateTime tijdstip4 = new DateTime(2021, 1, 20, 16, 00, 00);

            // We maken 5 afspraken aan, met elk hun eigen start- en
            // eindtijdstippen, en omschrijving die tijdens creatie van
            // de objecten wordt opgegeven...
            Afspraak afspraak1 = new Afspraak(tijdstip1, tijdstip2, "Tandarts");
            Afspraak afspraak2 = new Afspraak(tijdstip3, tijdstip4, "Boekhouder");
            Afspraak afspraak3 = new Afspraak(tijdstip2, tijdstip4, "Vaccinatie");
            Afspraak afspraak4 = new Afspraak(tijdstip1, tijdstip3, "Examen");
            Afspraak afspraak5 = new Afspraak(tijdstip2, tijdstip3, "Kapper");
            Afspraak afspraak6 = new Afspraak(tijdstip1, tijdstip4, "Autokeuring");

            Console.WriteLine("Alle aangemaakte afspraken zijn:");
            // De start, het einde en de omschrijving zijn verder (na creatie)
            // op te vragen (zie PrintAfspraak implementatie)...
            PrintAfspraak("afspraak1: ", afspraak1);
            PrintAfspraak("afspraak2: ", afspraak2);
            PrintAfspraak("afspraak3: ", afspraak3);
            PrintAfspraak("afspraak4: ", afspraak4);
            PrintAfspraak("afspraak5: ", afspraak5);
            PrintAfspraak("afspraak6: ", afspraak6);
            Console.WriteLine();

            // Maar kunnen niet meer worden aangepast...
            // afspraak1.Start = tijdstip4;         // zou een compilefout moeten opleveren
            // afspraak1.Einde = tijdstip4;         // zou een compilefout moeten opleveren
            // afspraak1.Omschrijving = "Oogarts";  // zou een compilefout moeten opleveren

            // Er kan worden nagegaan of een afspraak overlapt met een andere afspraak.
            // Uit onderstaande uitvoer kan je afleiden wat met overlapping wordt bedoeld...
            // bedoeld...
            Console.WriteLine("Overlappingen:");
            //
            Console.WriteLine($"afspraak3 overlapt met afspraak4: {afspraak3.Overlapt(afspraak4)}"); // True
            Console.WriteLine($"afspraak4 overlapt met afspraak3: {afspraak4.Overlapt(afspraak3)}"); // True
                                                                                                     //
            Console.WriteLine($"afspraak1 overlapt met afspraak4: {afspraak1.Overlapt(afspraak4)}"); // True
            Console.WriteLine($"afspraak4 overlapt met afspraak1: {afspraak4.Overlapt(afspraak1)}"); // True
                                                                                                     //
            Console.WriteLine($"afspraak4 overlapt met afspraak5: {afspraak4.Overlapt(afspraak5)}"); // True
            Console.WriteLine($"afspraak5 overlapt met afspraak4: {afspraak5.Overlapt(afspraak4)}"); // True
                                                                                                     //
            Console.WriteLine($"afspraak5 overlapt met afspraak6: {afspraak5.Overlapt(afspraak6)}"); // True
            Console.WriteLine($"afspraak6 overlapt met afspraak5: {afspraak6.Overlapt(afspraak5)}"); // True
                                                                                                     //
            Console.WriteLine($"afspraak1 overlapt met afspraak2: {afspraak1.Overlapt(afspraak2)}"); // False
            Console.WriteLine($"afspraak2 overlapt met afspraak1: {afspraak2.Overlapt(afspraak1)}"); // False
                                                                                                     //
            Console.WriteLine($"afspraak1 overlapt met afspraak3: {afspraak1.Overlapt(afspraak3)}"); // False
            Console.WriteLine($"afspraak3 overlapt met afspraak1: {afspraak3.Overlapt(afspraak1)}"); // False
                                                                                                     //
            Console.WriteLine();

            // Alle aparte afspraak objecten worden aan een lijst toegevoegd...
            List<Afspraak> agenda = new List<Afspraak>() { afspraak1, afspraak2, afspraak3, afspraak4, afspraak5, afspraak6 };

            // De lijst kan worden gesorteerd op tijdsduur bij wijze van de TijdsduurComparer...
            agenda.Sort(new TijdsduurComparer());

            Console.WriteLine("Alle afspraken gesorteerd op tijdsduur:");
            foreach (Afspraak a in agenda)
            {
                PrintAfspraak("- ", a);
            }
        }

        static void PrintAfspraak(string label, Afspraak a)
        {
            Console.WriteLine($"{label}{a.Start} - {a.Einde}: {a.Omschrijving}");
        }
    }
    
}
