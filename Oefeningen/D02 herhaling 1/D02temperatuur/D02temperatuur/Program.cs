namespace D02temperatuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef de temperatuur in Fahrenheit in: ");
            double tempF = double.Parse(Console.ReadLine());

            double tempC = 5.0 / 9 * (tempF - 32);

            Console.WriteLine(tempC);
        }
    }
}
