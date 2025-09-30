using System;

namespace D09_herkansing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Schrijf een programma dat op basis van een puntenlijst meldt of er al dan niet een herkansing moet ingericht worden.
            // Indien er minstens 1 student een onvoldoende behaalde(score<10) moet er een herkansing worden ingericht.


            int[] puntenlijst = { 13, 16, 13, 18, 8, 12, 15, 3, 4, 11, 17, 18 };

            

            bool isHerkansing = false;

            foreach (int score in puntenlijst)  
            {
                if(score < 10)
                {
                    isHerkansing = true;
                    break;
                }
            }

            if (isHerkansing)
            {
                Console.WriteLine("Er is herkansing nodig.");
            }
            else
            {
                Console.WriteLine("Er is geen herkansing nodig.");
            }
        }
    }
}
