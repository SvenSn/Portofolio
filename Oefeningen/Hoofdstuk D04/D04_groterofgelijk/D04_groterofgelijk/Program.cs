namespace D04_groterofgelijk
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Schrijf een programma dat de gebruiker om twee getallen en naargelang de situatie "het eerste is groter",
            //"het tweede is groter" en "ze zijn gelijk" afbeeldt.
            Console.WriteLine("Geef het eerste getal in");
            int getal1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het tweede getal in");
            int getal2 = Int32.Parse(Console.ReadLine());

            if (getal1 > getal2)
            {
                Console.WriteLine("Het eerste getal is groter");
            }
            else
            {
                if (getal1 < getal2)
                {
                    Console.WriteLine("Het tweede getal is groter");
                }
                else
                {
                    Console.WriteLine("De getallen zijn gelijk");
                }

            }
        }
    }
}
