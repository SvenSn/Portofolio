namespace D05_grootstegetal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker meermaals om een getal vraagt (totdat de gebruiker een -1 ingeeft).
            //Voor de eenvoud gaan we er hier van uit dat de gebruiker netjes getallen invoert, je hoeft hier niet op te controleren.
            //Na afloop toont het programma wat het GROOTSTE GETAL was van alle getallen (de ingegeven -1 telt niet mee)
            //en HOE VAAK dit grootste getal voorkwam.

            int getal = 0;
            int groosteGetal = 0;
            int teller = 0;


            do
            {
                Console.WriteLine("Geef een getal in");
                getal = Int32.Parse(Console.ReadLine());
                    // zolang het getal niet -1 is de teller blijven bijtellen en het grootste getal value geven van getal
                if (getal != -1)
                {
                    teller++;
                    if (teller == 1 && getal > groosteGetal)
                    {
                        groosteGetal = getal;
                    }
                }

            }
            while (getal != -1);
            
            // als de teller niet gelijkend is aan 0 het grootste getal schrijven op de console
            if (teller != 0)
            {
                Console.WriteLine($"Het grooste getal was {groosteGetal}");
            }
            else
            {
                Console.WriteLine("Geen correcte getallen ingegeven");
            }
        }
    }
}
