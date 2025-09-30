using static System.Net.Mime.MediaTypeNames;

namespace D05_grootstegetalenaantal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker meermaals om een getal vraagt (totdat de gebruiker een -1 ingeeft).
            //Voor de eenvoud gaan we er hier van uit dat de gebruiker netjes getallen invoert, je hoeft hier niet op te controleren.

            //Na afloop toont het programma wat het GROOTSTE GETAL was van alle getallen(de ingegeven - 1 telt niet mee) en HOE VAAK dit grootste getal voorkwam.

            int groosteGetal = 0;
            int getal = 0;
            int teller = 0;
            int tellerGrootste = 0;
            do
            {
                Console.WriteLine("Geef een getal in");
                getal = Int32.Parse(Console.ReadLine());
                teller++;
                if (getal > groosteGetal)
                {
                    groosteGetal = getal;
                    tellerGrootste = 1;
                }
                else if (getal == groosteGetal)
                {
                    tellerGrootste++;
                }
            }
            while (getal != -1);

            if (teller != 0)
            {
                Console.WriteLine($"Het grooste getal is; {groosteGetal} en het kwam {tellerGrootste} voor.");
            } 
            else
            {
                Console.WriteLine("Geen geldige getallen in gegeven");
            }

        }
    }
}
