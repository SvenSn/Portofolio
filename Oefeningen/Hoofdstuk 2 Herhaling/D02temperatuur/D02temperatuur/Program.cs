namespace D02temperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef de temperatuur in Fahrenheit in ");
            string tempFText = Console.ReadLine();  
            double tempF = double.Parse(tempFText);

            double tempC = 5.0 / 9.0 * (tempF-32.0);

            Console.WriteLine("De temp in Celcius is " + tempC);

        }
    }
}
