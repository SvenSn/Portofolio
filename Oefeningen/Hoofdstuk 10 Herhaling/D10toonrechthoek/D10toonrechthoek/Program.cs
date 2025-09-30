
namespace D10toonrechthoek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef de breedte. ");
            int breedte = int.Parse(Console.ReadLine());

            Console.WriteLine("Geef de hoogte. ");
            int hoogte = int.Parse(Console.ReadLine());

            ShowVierkent(breedte,hoogte);
        }

        private static void ShowVierkent(int breedte, int hoogte)
        {
            for (int i = 0; i < hoogte; i++)
            {
                for(int j = 0; j < breedte; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
