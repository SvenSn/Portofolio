namespace D02leeftijd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef uw naam: ");
            string naam = Console.ReadLine();

            Console.Write("Geef uw leeftijd: ");
            int leeftijd = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Goeiedag {naam}, je bent dus {leeftijd} jaar oud.");
        }
    }
}
