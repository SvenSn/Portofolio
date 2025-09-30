namespace D02_evenSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een geheel getal vraagt en ofwel meldt of het getal even dan wel oneven is.

            //gebruiker vragen voor een geheel getal
            Console.WriteLine("Geef een geheel getal in:");
            int getal1 = Int32.Parse(Console.ReadLine());

            // kijken of het getal even of oneven is met modulo %
            string isGetalEven = getal1 % 2 == 0 ? "even" : "oneven";

            // uitprinten van resultaat
            Console.WriteLine($"Het getal is {isGetalEven}");
        }
    }
}
