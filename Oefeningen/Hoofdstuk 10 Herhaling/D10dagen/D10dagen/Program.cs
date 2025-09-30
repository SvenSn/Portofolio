
namespace D10dagen
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
                Console.WriteLine($"In {maanden[maand - 1]} van {jaar} zijn er {GetDagen(maand,jaar)} dagen.");
                Console.WriteLine();
            } while (true);




             static int GetDagen(int maand, int jaar)
            {
                int[] dagen = { 31, DagenFebruari(jaar), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                return dagen[maand - 1];
            }

            static int DagenFebruari(int jaartal)
            {
                int dagenFebruari = 28;
                if (IsSchrikkeljaar(jaartal))
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
}
