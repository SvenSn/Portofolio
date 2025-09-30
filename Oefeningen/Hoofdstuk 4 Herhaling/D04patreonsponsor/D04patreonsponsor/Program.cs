namespace D04patreonsponsor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoeveel euro wil je uitgeven? ");
            double getal = double.Parse(Console.ReadLine());


            string sponsor = "";

            if (getal < 1)
            {
                Console.WriteLine("Helaas , voor dit bedrag kun je niet sponsoren. ");
            }
            else if (getal < 2)
            {
                sponsor = "\"It's a binary buck\"";
            }
            else if (getal < 3.5)
            {
                sponsor = "\"Two's Complement\"";
            }
            else if (getal < 7 )
            {
                sponsor = "\"Nibble-Size\"";
            }
            else if (getal < 14)
            {
                sponsor = "\"Glorious 8-bit simplicity\"";
            }
            else if (getal < 28)
            {
                sponsor = "\"16-bit is the future\"";
            }
            else if (getal < 55.5)
            {
                sponsor = "\"Cooking with 32-Bits\"";
            }
            else if (getal >= 55.5)
            {
                sponsor = "\"Commodore 64\"";
            }

            Console.WriteLine($"Dan word je een {sponsor}");
            
        }
    }
}
