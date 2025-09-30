namespace D02_hetmaandieet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Op de maan weegt alles (ongeveer) 6 keer minder dan op de aarde. 
             * Schrijf een programma dat de gebruiker om een gewicht in kilogram vraagt (een geheel getal) 
             * en dan op de console toont hoeveel het op de maan zou wegen (een kommagetal).*/

            Console.WriteLine("Geef uw gewicht terug in een geheel getal");
            string gewichtTekst = Console.ReadLine();
            int gewicht = Int32.Parse(gewichtTekst);


            double maanGewicht = gewicht / 6.0;

            Console.WriteLine($"Op de maan zou je ongeveer {maanGewicht} KG wegen");
        }
    }
}
