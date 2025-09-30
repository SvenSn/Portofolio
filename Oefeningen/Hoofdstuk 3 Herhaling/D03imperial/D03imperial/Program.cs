namespace D03imperial
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const double cmInFoot = 30.48;
            const double cmInInches = 2.54;

            Console.Write("Geef het aantal feet : ");
            string aantalFeetAlsTekst = Console.ReadLine();
            double aantalFeet = double.Parse(aantalFeetAlsTekst);

            Console.Write("Geef het aantal inches : ");
            string aantalInchesAlsTekst = Console.ReadLine();
            double aantalInches = double.Parse(aantalInchesAlsTekst);

            double aantalFeetInCm = aantalFeet * cmInFoot;
            double aantalInchesInCm = aantalInches * cmInInches;

            double totaalInCm = aantalFeetInCm + aantalInchesInCm;

            Console.WriteLine($"Dat is {totaalInCm}cm.");
        }
    }
}
