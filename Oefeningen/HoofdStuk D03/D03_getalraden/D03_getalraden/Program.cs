namespace D03_getalRaden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat een random getal bepaalt tussen 0 en 10 en de gebruiker 1 kans geeft om het te raden. 
            // Het programma toont of de gok van de gebruiker juist of fout was

            // gebruiker vragen om een getal in te voeren tussen 0 en 10 en getal type int geven en de string parsen naar int 
            Console.WriteLine(" De pc denkt aan een getal tussen 0 en 10");
            Console.WriteLine("Welk getal denk je dat het is?");
            int getal = Int32.Parse(Console.ReadLine());

            // nieuwe instantie maken van de klasse random genaamt r 
            Random r = new Random();
            // int gok aanmaken met als value een random getal tussen 0 en 10 met als ondergrens 1 
            int gok = r.Next(1,10);
            
            //if schrijven om de kijken of het geraden getal correct is of niet en bijhorende tekst weer te geven
            if (gok == getal) 
            { 
                Console.WriteLine($"Je hebt goed geraden het getal is: {gok} ");
            }
            else
            {
                Console.WriteLine($"Je hebt slecht gerdan het getal is: {gok}");
            }


        }
    }
}
