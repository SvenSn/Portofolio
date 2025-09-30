using System.ComponentModel.Design;

namespace D04_geslaagd
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Schrijf een programma dat de gebruiker om drie scores op 10 vraagt en vervolgens "geslaagd" of "niet geslaagd" toont.

            const int minimumScore = 4;
            const int halfScore = 5;

            Console.WriteLine("Geef het eerste resultaat");
            int score1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het eerste resultaat");
            int score2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het eerste resultaat");
            int score3 = Int32.Parse(Console.ReadLine());

            int totaalScore = score1 + score2 + score3;

            if (score1 >= halfScore && score2 >= halfScore && score3 >= halfScore )
            {
                
                //totale score printen voor zelf controle
                Console.WriteLine($"Je bent geslaagt! Uw totale score bedraagt: {totaalScore}");
                
               
            }
            else if (totaalScore >= 18 && score1 >= minimumScore && score2 >= minimumScore && score3 >= minimumScore)
            {
                Console.WriteLine($"Je bent geslaagt! je totalescore bedraagt: {totaalScore}");
            }
            else
            {
                Console.WriteLine("Je bent niet geslaagt");
            }
        }
    }
}
