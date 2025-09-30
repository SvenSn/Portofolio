namespace D04groterofgelijk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om twee getallen en naargelang de situatie "het eerste is groter", "het tweede is groter" en "ze zijn gelijk" afbeeldt.

            Console.WriteLine("Geef een getal. ");
            string getal1Text = Console.ReadLine();
            int getal1 = int.Parse(getal1Text);

            Console.WriteLine("Geef een getal in. ");
            string getal2Text = Console.ReadLine();
            int getal2 = int.Parse(getal2Text);

            


            if (getal1 > getal2)
            {
                Console.WriteLine($"Het eerste getal is groter. ");
            }
            else if (getal1 < getal2)
            {
                Console.WriteLine($"Het tweede getal is groter. ");
            }
            else
            {
                Console.WriteLine("Ze zijn gelijk. ");
            }

           

        }
    }
}
