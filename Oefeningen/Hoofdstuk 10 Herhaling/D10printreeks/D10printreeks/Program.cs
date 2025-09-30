
namespace D10printreeks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintReeks(10, 15);
            PrintReeks(8, 3);
            PrintReeks(4, 4);
        }

        private static void PrintReeks(int min, int max)
        {
            if (max < min)
            {
                PrintReeks(max, min);
            }
            else
            {
                int getal = min;
                while (getal < max)
                {
                    Console.Write(getal + " > ");
                    getal++;
                }

                Console.WriteLine(getal);
            }
        }
    }
}
