
namespace D10_dagenfebruari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maak zelf een method die antwoord op de vraag hoeveel dagen er in februari zijn van een bepaald jaar.


            do
            {
                Console.Write("Jaar?: ");
                int jaar = int.Parse(Console.ReadLine());
                Console.WriteLine($"In februari van {jaar} zijn er {AantalDagenFeb(jaar)} dagen.");
                Console.WriteLine();
            } while (true);
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
