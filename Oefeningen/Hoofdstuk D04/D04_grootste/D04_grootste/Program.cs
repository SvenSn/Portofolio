namespace D04_grootste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat 3 getallen van de gebruiker inleest en achteraf meldt wat het grootste getal is van de drie.
            //Bv. Als de gebruiker 2 8 en 4 ingeeft toont het programma "Het grootste getal van 2, 8 en 4 is 8".


            Console.WriteLine("Geef het eerste getal in.");
            int getal1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het tweede getal in.");
            int getal2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het derde getal in.");
            int getal3 = Int32.Parse(Console.ReadLine());


            int tussenStap = Math.Max(getal1, getal2);
            int grootsteGetal = Math.Max(tussenStap, getal3);


            Console.WriteLine($"Het grootste getal uit {getal1} ,{getal2} ,{getal3} is {grootsteGetal}");
        }
    }
}
