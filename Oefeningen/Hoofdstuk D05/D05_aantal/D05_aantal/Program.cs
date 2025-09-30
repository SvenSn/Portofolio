namespace D05_aantal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker meermaals om een getal vraagt,
            //totdat de gebruiker twee keer na elkaar hetzelfde getal ingeeft.
            //Voor de eenvoud gaan we er hier van uit dat de gebruiker netjes getallen invoert, je hoeft hier niet op te controleren.
            // Na afloop toont het programma het aantal ingegeven getallen(de laatste twee getallen tellen niet mee).

            int getal = 0;
            int teller = 0;
            int prevGetal = 0;

            do
            {
                prevGetal = getal;
                Console.WriteLine("Geef een getal in.");
                getal = Int32.Parse(Console.ReadLine());
                teller++;

            }
            while (teller < 2 || getal != prevGetal);

            teller -= 2;

            Console.WriteLine($"Het getal kwam {teller} voor.");

        }
    }
}
