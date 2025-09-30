namespace D07veelvoudenvan9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 15; i += 2)
            {
                int resultaat = 9 * i;
                Console.WriteLine($"{i,2:d} x 9 = {resultaat,3:d}");
            }
        }
    }
}
