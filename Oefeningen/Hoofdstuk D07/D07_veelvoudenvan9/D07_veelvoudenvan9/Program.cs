namespace D07_veelvoudenvan9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i <= 15; i += 2)
            {
                int getal1 = 9;
                int resultaat = getal1 * i;

                Console.WriteLine($"{i, 2:d} x {getal1} = {resultaat, 3:d}");

            }
        }
    }
}
