namespace D04oefeningpatreonsponsor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoeveel euro wil je uitgeven?: ");
            double getal = double.Parse(Console.ReadLine());

            string sponsorTitel = "";

            if (getal >= 55.5)
            {
                sponsorTitel = "Commodore 64";
            }
            else if (getal >= 28)
            {
                sponsorTitel = "Cooking with 32-bits";
            }
            else if (getal >= 14)
            {
                sponsorTitel = "16-bit is the future";
            }
            else if (getal >= 7)
            {
                sponsorTitel = "Glorious 8-bit simplicity";
            }
            else if ( getal >= 3.5)
            {
                sponsorTitel = "Nibble-Size";
            }
            else if (getal >= 2)
            {
                sponsorTitel = "Two's Complement";
            }
            else if (getal >= 1)
            {
                sponsorTitel = "It's a binary buck";
            }
            else
            {
                Console.WriteLine("Helaas, voor dit bedrag kan je niet sponsoren.");
            }

            Console.WriteLine($"Dan word je \"{sponsorTitel}\"");
        }
    }
}
