
namespace D10faculteit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een getal in. ");
            string invoer = Console.ReadLine();
            int getal = int.Parse(invoer);

            int faculteitGetal = faculteit(getal);

            Console.WriteLine($"{getal}! is {faculteitGetal}");
        }

        private static int faculteit(int getal)
        {
            int resultaat = 1; 
            for (int i = 2; i <= getal; i++)
            {
                resultaat = resultaat * i;
            }

            return resultaat;
        }
    }
}
