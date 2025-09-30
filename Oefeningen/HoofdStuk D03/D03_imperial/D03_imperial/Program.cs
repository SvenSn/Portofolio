namespace D03_imperial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dit programma vraagt de gebruiker om een afstand in feet en inches, en toont dan de equivalente afstand in centimeter.
            // Vervang de magic values in dit programma door const variabelen.

            Console.Write("Geef het aantal feet : ");
            string aantalFeetAlsTekst = Console.ReadLine();
            double aantalFeet = double.Parse(aantalFeetAlsTekst);

            Console.Write("Geef het aantal inches : ");
            string aantalInchesAlsTekst = Console.ReadLine();
            double aantalInches = double.Parse(aantalInchesAlsTekst);

            // constante doubles aanmaken voor cm in foot en cm in inches omdat deze een vaste waarde hebben 
            const double cmInFt = 30.48;
            const double cmInInch = 2.54;

            double aantalFeetInCm = aantalFeet * cmInFt;
            double aantalInchesInCm = aantalInches * cmInInch;

            double totaalInCm = aantalFeetInCm + aantalInchesInCm;

            Console.WriteLine($"Dat is {totaalInCm}cm.");
        }
    }
}
