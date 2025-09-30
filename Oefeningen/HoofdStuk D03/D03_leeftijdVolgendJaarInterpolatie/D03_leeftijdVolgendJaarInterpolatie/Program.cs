namespace D03_leeftijdVolgendJaarInterpolatie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //gebruiker vragen om naam in te geven
            Console.WriteLine("Geef uw naam in:");
            string naam = Console.ReadLine();

            //gebruiker vragen om leeftijd en leeftijd parsen naar int van een string type
            Console.WriteLine("Geef uw leeftijd in: ");
            int leeftijd = Int32.Parse(Console.ReadLine());

            // maak een value met type int voor leeftijd volgend jaar
            int leeftijdVolgendJaar = leeftijd + 1;

            //weergeven van leeftijd , naam en leeftijd volgend jaar 
            Console.WriteLine($"Oei oei {naam} je bent volgend jaar al {leeftijdVolgendJaar} jaar oud!");
        }
    }
}
