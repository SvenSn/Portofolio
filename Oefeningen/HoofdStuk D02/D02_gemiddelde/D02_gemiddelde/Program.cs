namespace D02_gemiddelde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om drie kommagetallen vraagt en hun gemiddelde toont.  

            Console.WriteLine("Geef het eerste komma getal in:");
            string eersteGetalTekst = Console.ReadLine();
            double eersteGetal = double.Parse(eersteGetalTekst);

            Console.WriteLine("Geef het tweede komma getal in:");
            string tweedeGetalTekst = Console.ReadLine();
            double tweedeGetal = double.Parse(tweedeGetalTekst);

            Console.WriteLine("Geef het derde komma getal in:");
            string derdeGetalTekst = Console.ReadLine();
            double derdeGetal = double.Parse(derdeGetalTekst);

            double gemiddelde = (eersteGetal+tweedeGetal+derdeGetal)/3;

            Console.WriteLine($"Het gemiddelde is: {gemiddelde}.");
      
        }
    }
}
