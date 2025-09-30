namespace D02_quotient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*  Maak een programma dat de gebruiker om een deeltal en een deler vraagt en vervolgens het quotient op de console toont.
                Indien de gebruiker voor de deler een nul invoert, is de deling niet toegelaten en wordt dit gemeld. */

            Console.WriteLine("Geef een deeltal in:");
            string deeltalTekst = Console.ReadLine();
            double deeltal = double.Parse(deeltalTekst);

            Console.WriteLine("Geef een deler in");
            string delerTekst = Console.ReadLine() ;
            double deler = double.Parse(delerTekst);

            

            if (deler == 0) 
            {
                Console.WriteLine("0 als deler is niet toegelaten.");
            }
            else
            {
                double resultaat = deeltal / deler;
                Console.WriteLine($"Het quotient is: {resultaat}");
            }
        }
    }
}
