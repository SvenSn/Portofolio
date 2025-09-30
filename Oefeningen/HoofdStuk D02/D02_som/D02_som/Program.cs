namespace D02_som
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om 2 gehele getallen vraagt(bv. 5 en 6) en hun som op de console zet:5 plus 6 is 11.

            Console.WriteLine("Geef het eerste gehele getal in:");
            string getal1Tekst = Console.ReadLine();
            int getal1 = Int32.Parse(getal1Tekst);

            Console.WriteLine("Geef het tweede gehele getal in:");
            string getal2Tekst = Console.ReadLine();   
            int getal2 = Int32.Parse(getal2Tekst);

            int resultaat = getal1 + getal2;


            Console.WriteLine($"{getal1} plus {getal2} is {resultaat}.");
        }
    }
}
