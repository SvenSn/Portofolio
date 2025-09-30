namespace D04groterofgelijk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef het eerste gehele getal in: ");
            int getal1 = int.Parse(Console.ReadLine());

            Console.Write("Geef het tweede gehele getal in: ");
            int getal2 = int.Parse(Console.ReadLine());

            if (getal1 > getal2)
            {
                Console.WriteLine("Het eerste getal is groter.");
            }else if (getal1 < getal2)
            {
                Console.WriteLine("Het tweede getal is groter");
            }else
            {
                Console.WriteLine("De getallen zijn gelijk");
            }
        }
    }
}
