namespace D02_absolutewaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Schrijf een programma dat de gebruiker om een getal vraagt en de absolute waarde van dit getal toont.
               De absolute waarde
               van een positief getal is het getal zelf
               van een negatief getal is het getal zonder minteken ervoor */

            Console.WriteLine("Geef een getal in:"); 
            string getalTekst = Console.ReadLine();
            int getal = Int32.Parse(getalTekst);

            int echteValue = getal;

            if (getal < 0)
            {
                echteValue = getal * (-1);
            }

            Console.WriteLine($"De absolute waarde van het getal is {echteValue}.");
        
        }
    }
}
