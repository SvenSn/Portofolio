
namespace D11getclamped
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Voorbeeld GetClamped met min=3 en max=6");
            for (int i = 1; i <= 8; i++)
            {
                int clamped = GetClamped(3, i, 6);
                Console.WriteLine($"voor {i} geeft dit {clamped}");
            }
        }

        private static int GetClamped(int min, int getal, int max)
        {
            int resultaat = 0;

            if (min <= getal && getal <= max)
            {
                resultaat = getal;
            }
            else if (getal < min)
            {
                resultaat = min;
            }else
            {
                resultaat = max;
            }
            return resultaat;
        }
    }
}
