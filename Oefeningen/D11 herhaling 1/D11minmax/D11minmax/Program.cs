

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
            int min = getallen[0];
            for (int i = 0; i < getallen.Length; i++)
            {
                if (getallen[i] < min)
                {
                    min = getallen[i];
                }
            }
            return min;
        }

        private static int BepaalMaximum(int[] getallen)
        {
            int max = getallen[0];
            

            for (int i = 0; i < getallen.Length; i++)
            {
                if (getallen[i] > max)
                {
                    max = getallen[i];
                }
            }
            return max;
        }
    }
}
