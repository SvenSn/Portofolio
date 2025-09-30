namespace D02_even
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Schrijf een programma dat de gebruiker om een geheel getal vraagt en ofwel meldt of het getal even dan wel oneven is.

            Console.WriteLine("Geef een geheel getal in:");
            string geheelGetalTekst = Console.ReadLine();
            int geheelGetal = Int32.Parse(geheelGetalTekst);

            if (geheelGetal %2 == 0)
            {
                Console.WriteLine($"Het getal {geheelGetal} is even.");
            }

            else
            {
                Console.WriteLine($"Het getal {geheelGetal} is oneven.");
            }

        }
    }
}
