
namespace D11minmax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat een array met getallen definieert en vervolgens toont wat het kleinste en het grootste getal is in dat array.

            //Schrijf hiervoor 2 methods, BepaalMinimum en BepaalMaximum,
            //die beiden een array met getallen als parameter krijgen en resp het kleinste of grootste getal retourneren uit het meegegeven array.

            int[] getallen = { -4, 7, 9, 34, 2, 56, 34, 78 };
            Console.WriteLine(BepaalMinimum(getallen));
            Console.WriteLine(BepaalMaximum(getallen));

        }

        private static int BepaalMaximum(int[] getallen)
        {
            int max = 0;

           for (int i = 0; i < getallen.Length; i++)
            {
                if (getallen[i] > max)
                {
                    max = getallen[i];
                }
            }
           return max;
        }

        private static int BepaalMinimum(int[] getallen)
        {
            int min = 0;    

            for(int i = 0;i < getallen.Length;i++)
            {
                if(getallen[i] < min)
                {
                    min = getallen[i];
                }
            }
            return min;
        }
    }
}
