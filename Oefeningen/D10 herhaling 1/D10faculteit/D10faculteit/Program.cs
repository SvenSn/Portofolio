
namespace D10faculteit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetFaculteit(5);
        }

        private static void GetFaculteit(int getal)
        {
            int resultaat = 1;

            for (int i = getal; i > 0; i--)
            {
                resultaat = resultaat * i;
            }
            Console.WriteLine($"{getal}! is {resultaat}");
        }
    }
}
