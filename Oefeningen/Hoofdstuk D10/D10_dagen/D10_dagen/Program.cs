
namespace D10_dagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Maand?: ");
                int maand = int.Parse(Console.ReadLine());
                Console.Write("Jaar?: ");
                int jaar = int.Parse(Console.ReadLine());
                string[] maanden = {"januari", "februari", "maart", "april", "mei", "juni", "juli",
                        "augustus", "september", "oktober", "november", "december"};
                Console.WriteLine($"In {maanden[maand - 1]} van {jaar} zijn er {HoeveelDagen(maand,jaar)} dagen.");
                Console.WriteLine();
            } while (true);
        }

        private static object HoeveelDagen(int maand,int jaartal)
        {
            int[] dagen = {31,AantalDagenFeb(jaartal),31,30,31,30,31,31,30,31,30,31 };
            return dagen[maand-1];  
        }
        private static int AantalDagenFeb(int jaartal)
        {
            int dagen = 28;
            if (IsSchrikkeljaar(jaartal))
            {
                dagen++;
            }
            return dagen;
        }


        static bool IsSchrikkeljaar(int jaartal)
            {
                 return (jaartal % 400 == 0 || jaartal % 4 == 0 && jaartal % 100 != 0);
            }
    }
    
}
