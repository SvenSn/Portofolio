namespace D02hetmaandieet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef je gewicht in kg: ");
            string gewichtText = Console.ReadLine();    
            int gewicht = int.Parse(gewichtText);

            double gewichtMaan = gewicht / 6.0;

            Console.WriteLine($"Op de maan zou je ongeveer {gewichtMaan} wegen ");

        }
    }
}
