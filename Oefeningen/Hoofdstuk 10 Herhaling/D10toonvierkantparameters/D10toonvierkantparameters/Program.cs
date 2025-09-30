
namespace D10toonvierkantparameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToonVierkant(5, 5);
        }

        private static void ToonVierkant(int hoogte, int breedte)
        {
            for (int i = 0; i < hoogte; i++)
            {
                for(int j = 0; j < breedte; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();    
            }
        }
    }
}
