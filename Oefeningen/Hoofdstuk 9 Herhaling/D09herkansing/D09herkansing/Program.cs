namespace D09herkansing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] puntenlijst = { 13, 16, 13, 18, 8, 12, 15, 3, 4, 11, 17, 18 };

            bool isHerkansing = false;

            const int score = 10;

            foreach (int i in puntenlijst)
            {
                if (i < score)
                {
                    isHerkansing = true;
                }
            }

            if (isHerkansing)
            {
                Console.WriteLine("Herkansing is nodig. ");

            }
            else
            {
                Console.WriteLine("Geen herkansing nodig");
            }

        }
    }
}
