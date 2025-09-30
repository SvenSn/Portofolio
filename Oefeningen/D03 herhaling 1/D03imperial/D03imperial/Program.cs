namespace D03imperial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double cmPerFoot = 30.48;
            const double cmPerInch = 2.54;
            Console.Write("Geef het aantal feet : ");
            string aantalFeetAlsTekst = Console.ReadLine();
            double aantalFeet = double.Parse(aantalFeetAlsTekst);

            Console.Write("Geef het aantal inches : ");
            string aantalInchesAlsTekst = Console.ReadLine();
            double aantalInches = double.Parse(aantalInchesAlsTekst);

            double aantalFeetInCm = aantalFeet * cmPerFoot;
            double aantalInchesInCm = aantalInches *  cmPerInch;

            double totaalInCm = aantalFeetInCm + aantalInchesInCm;

            Console.WriteLine($"Dat is {totaalInCm}cm.");
        }
    }
}
