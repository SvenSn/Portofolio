
namespace D10toonsomtussen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 5;
            int max = 10;
            

            int som = ShowSumBetween(min,max);

            Console.WriteLine(som);
        }

        private static int ShowSumBetween(int min, int max)
        {
            int som = 0;
            for (int i = min; i <= max; i++)
            {
                som += i;
            }
            return som;
        }
    }
}
