
namespace D11minmax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] getallen = { -4, 7, 9, 34, 2, 56, 34, 78 };
            Console.WriteLine(BepaalMinimum(getallen));
            Console.WriteLine(BepaalMaximum(getallen));
        }

        private static int BepaalMinimum(int[] getallen)
        {
            int min = Int32.MaxValue;

            foreach (int getal in getallen)
            {
                if (getal < min)
                {
                    min = getal;
                }
            }

            return min;
        }

        private static int BepaalMaximum(int[] getallen)
        {
            int max = Int32.MinValue;   

            foreach (int getal in getallen)
            {
                if (getal > max)
                {
                    max = getal;
                }
            }

            return max;
        }
    }
}
