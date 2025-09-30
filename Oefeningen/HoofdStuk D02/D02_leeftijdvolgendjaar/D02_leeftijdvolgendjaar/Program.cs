using System;

namespace D02_leeftijdvolgendjaar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Schrijf een programma dat de gebruiker om zijn/haar naam (bv. Jan) en leeftijd (bv. 34), er een jaartje bijtelt en het volgende zinnetje toont
            Oei oei Jan, volgend jaar ben je al 35 jaar oud!*/
            Console.WriteLine("Geef uw naam in.");
            string naam = Console.ReadLine();

            Console.WriteLine("Geef uw leeftijd in.");
            string leeftijdTekst = Console.ReadLine();
            int leeftijd = int.Parse(leeftijdTekst);

            int leeftijdVolgendJaar = leeftijd + 1;

            Console.WriteLine($"Oei Oei {naam}, Volgend jaar ben je al {leeftijdVolgendJaar} oud!");
        }
    }
}
