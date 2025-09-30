using static System.Runtime.InteropServices.JavaScript.JSType;

namespace D04_schrikkeljaar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maak een programma dat van een ingevoerd jaartal op de console brengt of het gaat om een schrikkeljaar of niet.
            //Een schrikkeljaar is een jaar dat deelbaar is door 4 en niet door 100, of deelbaar is door 400.



            Console.WriteLine("Geef en jaartal in.");
            int jaartal = Int32.Parse(Console.ReadLine());

            bool vierDeelbaar = (jaartal % 4 == 0);
            bool honderdDeelbaar = (jaartal % 100 == 0);
            bool vierHonderdDeelbaar = (jaartal % 400 == 0);

            if (vierDeelbaar && !honderdDeelbaar || vierHonderdDeelbaar)
            {
                Console.WriteLine("Het is een schrikkeljaar");
            }
            else
            {
                Console.WriteLine("Het is geen schrikkeljaar");
            }


        }
    }
}
