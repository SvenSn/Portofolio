
namespace D10dagenfebruari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Jaar?: ");
                int jaar = int.Parse(Console.ReadLine());



                Console.WriteLine($"In februari van {jaar} zijn er {DagenFebruari(jaar)} dagen.");
                Console.WriteLine();
            } while (true);
        }

        private static object DagenFebruari(int jaar)
        {
            int dagenFebruari = 28;
            if (IsSchrikkeljaar(jaar))
            {
                dagenFebruari++;
            }
            return dagenFebruari;
        }

        static bool IsSchrikkeljaar(int jaartal)
        {
            return (jaartal % 400 == 0 || jaartal % 4 == 0 && jaartal % 100 != 0);
        }
    }
}
