namespace D02_som
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maak een programma dat de gebruiker vraagt hoeveel muntstukken van 2 en 1 euro hij heeft en vervolgens het totale bedrag toont.
            Console.WriteLine("Geef aantal muntstukken van 2 euro in.");
            string tweeEuroTekst = Console.ReadLine(); 
            //omzetten van string naar int voor het aantal muntstukken
            int tweeEuro = Int32.Parse(tweeEuroTekst);

            Console.WriteLine("Geef aantal muntstukken van 1 euro in.");
            string eenEuroTekst = Console.ReadLine() ;

            int eenEuro = Int32.Parse(eenEuroTekst);

            int totaalBedrag = tweeEuro * 2 +
                                eenEuro;

            Console.WriteLine($"aantal muntstukken van 2 euro: {tweeEuro}");
            Console.WriteLine($"aantal muntstukken van 1 euro: {eenEuro}");
            Console.WriteLine($"Het totale bedrag is: {totaalBedrag} Euro.");




        }
    }
}
