
namespace D10temperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConvertFahrenheitToCelsius(55);
            Console.WriteLine(ConvertFahrenheitToCelsius(55));
        }

        private static double ConvertFahrenheitToCelsius(double tempF)
        {
            double tempC = (tempF - 32) * 5.0 / 9;

            return tempC;
        }
    }
}
