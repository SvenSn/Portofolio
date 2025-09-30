
namespace D10toonsomtussen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int min = 5;
            int max = 10;

            ToonSom(min,max);
        }

        private static void ToonSom(int min, int max)
        {
            int som = 0;
            for (int i = min; i <= max; i++)
            {
                som += i;
            }
            Console.WriteLine(som);
        }
    }
}
