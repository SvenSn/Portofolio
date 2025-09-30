

namespace D10toonrechthoek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een breedte in.");
            int breedte = int.Parse(Console.ReadLine());

            Console.WriteLine("Geef een hoogte in.");
            int hoogte = int.Parse(Console.ReadLine());

            toonrechthoek(breedte, hoogte);
        }

        private static void toonrechthoek(int breedte, int hoogte)
        {
            for(int i = 0; i < hoogte; i++)
            {
                for (int j = 0; j < breedte; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
