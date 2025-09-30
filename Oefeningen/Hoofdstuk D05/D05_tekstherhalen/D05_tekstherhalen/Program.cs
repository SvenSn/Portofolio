using System.ComponentModel;

namespace D05_tekstherhalen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst vraagt en een aantal,
            //vervolgens daarmee een nieuwe tekst bouwt en deze op de console toont.


            Console.WriteLine("Geef een tekst");
            string tekst = Console.ReadLine();

            Console.WriteLine("Geef een getal");
            int getal = Int32.Parse(Console.ReadLine());
            int tellen = 1;

            while (tellen < getal)
            {
                Console.Write(tekst);
                tellen++;
                if (tellen == getal )
                {
                    Console.Write(tekst.ToUpper());
                }
            }
           
                
        }
    }
}
