
namespace D10temperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef de temperatuur in Fahrenheit in. ");
            string invoer = Console.ReadLine();
            double tempF = double.Parse(invoer);

            Console.WriteLine("De temperatuur in celcius is " + ConvertTempF(tempF));

        }

        private static double ConvertTempF(double tempF)
        {
            double tempC = 5.0 / 9 * (tempF - 32);

            return tempC;
        }
    }
}
