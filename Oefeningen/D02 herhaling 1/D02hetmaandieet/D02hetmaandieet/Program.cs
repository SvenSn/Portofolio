namespace D02hetmaandieet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef uw gewicht in kg : ");

            int gewicht = Int32.Parse(Console.ReadLine());

            double gewichtMaan = gewicht / 6.0;

            Console.WriteLine($"op de maan zou je ongeveer {gewichtMaan} kg wegen");
        }
    }
}
