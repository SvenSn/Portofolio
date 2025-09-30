namespace D02_volwassen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om zijn/haar leeftijd vraagt en toont
            //Je bent wel volwassen. of Je bent niet volwassen.. Volwassen betekent 18 jaar of ouder.

            Console.WriteLine("Geef uw leeftijd in:");
            string leeftijdTekst = Console.ReadLine(); 
            int leeftijd = Int32.Parse(leeftijdTekst);

            Console.WriteLine("Je bent ");

            if (leeftijd >= 18) 
            {
                Console.WriteLine("wel");
            }
            else
            {
                Console.WriteLine("niet");

            }
            Console.WriteLine("volwassen");
            Console.WriteLine($"Je bent {leeftijd} jaar oud");

        }
    }
}
