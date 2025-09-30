namespace D03_cirkel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Schrijf een programma dat de gebruiker om de straal van een cirkel (een kommagetal!) vraagt
            // en vervolgens zowel de omtrek als de oppervlakte van de cirkel toont.


            Console.WriteLine("Geef de straal van cirkel in: ");
            double straal = double.Parse(Console.ReadLine());

            double omtrekCirkel = 2 * Math.PI * straal;
            double oppervlakteCirkel = Math.PI * Math.Pow(straal, 2);

            Console.WriteLine($" De omtrek van deze cirkel is {omtrekCirkel} en de oppervlakte is {oppervlakteCirkel}");
        }
    }
}
