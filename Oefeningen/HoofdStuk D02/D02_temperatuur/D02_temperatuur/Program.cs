namespace D02_temperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Schrijf een programma dat de gebruiker om een temperatuur in graden Fahrenheit (een kommagetal) 
             * vraagt en dan de corresponderende de temperatuur in graden Celsius (een kommagetal) toont.
            De formule voor de omzetting van graden Fahrenheit (F) naar graden Celsius (C) is : C = 5/9 * (F-32)*/


            Console.WriteLine("Geef de temperatuur in Fahrenheit");
            string tempFTekst = Console.ReadLine();
            double tempF = double.Parse(tempFTekst);

            double tempC = (5.0/9.0) * (tempF - 32.0);

            Console.WriteLine($"De temperatuur in celcius is: {tempC}");






        }
    }
}
