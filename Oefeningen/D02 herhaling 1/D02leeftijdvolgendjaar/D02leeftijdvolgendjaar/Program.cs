namespace D02leeftijdvolgendjaar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef uw naam: ");
            string naam = Console.ReadLine();

            Console.Write("Geef uw leeftijd: ");
            int leeftijd = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Oei oei {naam}, volgend jaar ben je al {leeftijd + 1} jaar oud!");
        }
    }
}
