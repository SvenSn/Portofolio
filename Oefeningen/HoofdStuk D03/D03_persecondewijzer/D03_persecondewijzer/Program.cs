namespace D03_persecondewijzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een geheel aantal seconden vraagt en toont hoeveel uren, minuten en seconden dit is.


            Console.WriteLine("Geef het aantal seconden in");
            int aantalSeconden = Int32.Parse(Console.ReadLine());

            // constante int's aanmaken van hoevel seconden er in een uur en minuut zitten 
            
            const int secondenInMinuut = 60;
            const int secondenInUur = 60 * secondenInMinuut;

            int restSec = aantalSeconden;
            int uren = aantalSeconden / secondenInUur;
            restSec = aantalSeconden % secondenInUur;
            int minuten = restSec / secondenInMinuut;
            restSec = restSec % secondenInMinuut;
            int secEind = restSec;

            Console.WriteLine($"Het aantal uren is : {uren} het aantal minuten is: {minuten} en het aantal seconden is: {restSec}");


        }
    }
}
