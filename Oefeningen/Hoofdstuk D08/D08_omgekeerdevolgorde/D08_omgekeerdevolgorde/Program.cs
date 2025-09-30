using System.Xml.Linq;
using System;

namespace D08_omgekeerdevolgorde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om 4 namen vraagt en deze vervolgens in de omgekeerde volgorde toont op de console.

            string[] namen = new string[4];


            for (int i = 0; i < namen.Length; i++)
            {
                Console.Write("Geef een naam: ");
                namen[i] = Console.ReadLine();
            }

            for (int index = 3; index >= 0; index--)
            {
                Console.WriteLine($"{namen[index]}");
            }
        }
    }
}
