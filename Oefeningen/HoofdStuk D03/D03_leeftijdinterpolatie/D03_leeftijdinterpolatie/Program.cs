namespace D03_leeftijdinterpolatie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ik heb altijd al interpolatie gebruikt ook bij d02 

            //Gebruiker vragen om naam in te geven , deze een type toekennen en initialiseren
            Console.WriteLine("Geef uw naam in: ");
            string naam = Console.ReadLine();

            //Gebruiker om leeftijd in te geven en type toekennen en parsen van int naar string
            Console.WriteLine("Geef uw leeftijd in: ");
            int leeftijd = Int32.Parse(Console.ReadLine());

            //Terug geven op scherm van de leeftijd en naam van de gebruiker met interpolatie van string
            Console.WriteLine($"Goeie dag {naam} en je bent {leeftijd} jaar oud");


        }
    }
}
