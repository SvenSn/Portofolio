namespace D03_sominterpolatie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef het eerste gehele getal in: ");
            int getal1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het tweede gehele getal in: ");
            int getal2 = Int32.Parse(Console.ReadLine());   

            int som = getal1 + getal2;

            Console.WriteLine($" {getal1}+{getal2} is gelijk aan {som}");
        }
    }
}
