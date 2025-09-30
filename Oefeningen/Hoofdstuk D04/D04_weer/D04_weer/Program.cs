using System;

namespace D04_weer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maak een programma om een bepaald weerbeeld af te drukken, we hebben vier mogelijkheden:
            //Regenboog. (indien het regent en de zon schijnt)
            //Slecht weer. (indien het regent en de zon niet schijnt)
            //Mooi weer. (indien het niet regent en de zon schijnt)
            //Saaie dag. (indien het niet regent en zon niet schijnt)

            Console.Write("Schijnt de zon (ja/nee)?: ");
            string zon = Console.ReadLine();
            bool deZonSchijnt = (zon == "ja");

            Console.Write("Regent het (ja/nee)?: ");
            string regen = Console.ReadLine();
            bool hetRegent = (regen == "ja");

            if (deZonSchijnt)
            {
                if (hetRegent)
                {
                    Console.WriteLine("Regenboog");
                }
                else if (!hetRegent) 
                {
                    Console.WriteLine("Mooi weer");
                }
                else
                {
                    Console.WriteLine("Saaie dag");
                }
            }
            else
            {
                Console.WriteLine("Slecht weer");
            }
        }
    }
}
