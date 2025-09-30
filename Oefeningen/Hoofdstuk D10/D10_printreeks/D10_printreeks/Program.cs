
namespace D10_printreeks
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
                int kleinsteGetal = min;

                while (kleinsteGetal < max)
                {
                    Console.Write(kleinsteGetal + ">");
                    kleinsteGetal++;
                }

                Console.WriteLine(kleinsteGetal);
            }
        }
    }
}
