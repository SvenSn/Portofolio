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
                Console.WriteLine($"In februari van {jaar} zijn er {DagenFebruari(IsSchrikkeljaar(jaar))} dagen.");
                Console.WriteLine();
            } while (true);


        }

        static int DagenFebruari(bool schrikkeljaar)
        {
            int dagen = 28;
            if(schrikkeljaar)
            {
                dagen = 29; 
            }
            else
            {
                dagen = 28;
            }
            return dagen;
        }


        static bool IsSchrikkeljaar(int jaartal)
        {
            return (jaartal % 400 == 0 || jaartal % 4 == 0 && jaartal % 100 != 0);
        }
    }
}
