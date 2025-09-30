using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System;

namespace D16namenalfabetisch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om namen vraagt en deze vervolgens alfabetisch gesorteerd op de console toont.
            //Het programma stopt met vragen zodra de gebruiker een lege tekst ingeeft(bv. 3 spaties invoert en op Enter drukt).

            List<string> namen = new List<string>();

            string naam;

            do
            {
                int aantal = namen.Count + 1;
                Console.Write($"Geef naam {aantal} in. ");
                naam = Console.ReadLine();

                if (naam != "")
                {
                    namen.Add(naam);
                }
            } while (naam != "");

            namen.Sort();

            foreach (string n in namen)
            {
                Console.WriteLine(n);
            }


        }
    }
}
