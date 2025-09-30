
namespace D10toonvierkent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToonVierkant();
        }

        private static void ToonVierkant()
        {
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
