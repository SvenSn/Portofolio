namespace D04_patreonsponsor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
            vanaf 1    Eur : It's a binary buck
            vanaf 2    Eur : Two's Complement
            vanaf 3.5  Eur : Nibble-Size
            vanaf 7    Eur : Glorious 8-bit simplicity
            vanaf 14   Eur : 16-bit is the future
            vanaf 28   Eur : Cooking with 32-bits
            vanaf 55.5 Eur : Commodore 64*/
            /* Schrijf een programma dat de gebruiker om een geldbedrag vraagt en vervolgens het bereikte sponsor niveau (tussen aanhalingstekens!) weergeeft.
             * Gebruik hiervoor interval checking​​ zoals uitgelegd in de cursus.*/

            Console.WriteLine("Hoeveel wil je betalen?");
            double patreonPrijs = double.Parse(Console.ReadLine());

            string patreonNaam = "It's a binary buck";

            if (patreonPrijs >= 55.5)
            {
                patreonNaam = "Commodore 64";
            }
            else if (patreonPrijs >= 28)
            {
                patreonNaam = "Cooking with 32-bits";
            }
            else if (patreonPrijs >= 14)
            {
                patreonNaam = "16-bit is the future";
            }
            else if (patreonPrijs >= 7)
            {
                patreonNaam = "Glorious 8-bit simplicity";
            }
            else if (patreonPrijs >= 3.5)
            {
                patreonNaam = "Nibble-size";
            }
            else if (patreonPrijs >= 2)
            {
                patreonNaam = "Two's complement";
            }
            else if(patreonPrijs < 1)
            {
                Console.WriteLine("U kan niet onder 1 euro betalen");
                patreonNaam = "Niets";
            }

            Console.WriteLine($"Je doneerde {patreonPrijs} en je patreon titel is {patreonNaam}");
        }
    }
}
