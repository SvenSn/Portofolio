namespace D10toonvierkantmetparameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToonVierkant(4);
        }
        private static void ToonVierkant(int b)
        {
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
