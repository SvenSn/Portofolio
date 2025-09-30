namespace D02_volwassenSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om zijn/ haar leeftijd vraagt en toont Je bent wel volwassen. of Je bent niet volwassen..
            //Volwassen betekent 18 jaar of ouder.

            //vraag gebruiker voor leeftijd 
            Console.WriteLine("Geef uw leeftijd in ");
            int leeftijd = Int32.Parse(Console.ReadLine());

            string volwassen = leeftijd < 18 ? "Niet" : "Wel";

            Console.WriteLine($"Je bent {volwassen} volwassen");
        }
    }
}
