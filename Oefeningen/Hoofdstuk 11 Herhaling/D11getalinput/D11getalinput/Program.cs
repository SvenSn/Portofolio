
namespace D11getalinput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int getal = GetGetal(1, 100);
            Console.WriteLine($"U koos voor {getal}");
        }

        private static int GetGetal(int min, int max)
        {
            int getal;
            bool gelukt;
            do
            {
                Console.Write($"Geef een getal van {min} tot en met {max} : ");
                string invoer = Console.ReadLine();
                gelukt = int.TryParse(invoer, out getal);
            } while (!gelukt || getal < min || getal > max);

            return getal;
        }
    }
}
