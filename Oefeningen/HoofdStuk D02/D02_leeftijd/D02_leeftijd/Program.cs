using System;

namespace D02_leeftijd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Schrijf een programma dat de gebruiker om zijn/ haar naam(bv.Jan) en leeftijd(bv. 34) vraagt en volgende zinnetje op de console zet :
            Goeiedag Jan, je bent dus 34 jaar oud!*/

            Console.WriteLine("Geef uw naam in.");
            string naam = Console.ReadLine();

            Console.WriteLine("Geef uw leeftijd in.");
            string leeftijd = Console.ReadLine();

            Console.WriteLine($"Goeiedag {naam}, je bent dus {leeftijd} oud.");
        }
    }
}
