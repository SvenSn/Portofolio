namespace D02leeftijd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een naam : ");
            string naam = Console.ReadLine();

            Console.Write("Geef je leeftijd. ");
            string leeftijd = Console.ReadLine();

            int leeftijdNr = int.Parse(leeftijd);

            Console.WriteLine($"Goeiedag {naam}, jij bent dus {leeftijdNr} jaar oud!");
        }
    }
}
