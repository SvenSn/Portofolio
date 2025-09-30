
namespace D11clamped
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method GetClamped met 3 int parameters : min, getal en max. Het nut van deze method is dat ze altijd een waarde teruggeeft die tussen min en max ligt (grenzen incl.).

            Console.WriteLine("Voorbeeld GetClamped met min=3 en max=6");
            for (int i = 1; i <= 8; i++)
            {
                int clamped = GetClamped(3, i, 6);
                Console.WriteLine($"voor {i} geeft dit {clamped}");
            }


        }

        private static int GetClamped(int min, int getal, int max)
        {

            if (getal < min)
            {
                return min;
            }
            else if (getal > max)
            {
                return max;
            }
            else
            {
                return getal;
            }
            
        }
    }
}
