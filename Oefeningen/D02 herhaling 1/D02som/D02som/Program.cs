namespace D02som
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef het eerste gehele getal in: ");
            int getal1 = Int32.Parse(Console.ReadLine());

            Console.Write("Geef het tweede gehele getal in: ");
            int getal2 = Int32.Parse(Console.ReadLine());

            int som = getal1 + getal2;

            Console.WriteLine($"{getal1} plus {getal2} is {som}");
        }
    }
}
