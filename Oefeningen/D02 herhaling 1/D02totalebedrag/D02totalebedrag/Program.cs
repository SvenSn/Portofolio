namespace D02totalebedrag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Aantal muntstukken van 2 euro: ");
            int muntstuk2euro = Int32.Parse(Console.ReadLine());

            Console.Write("Aantal muntstukken van 1 euro: ");
            int muntstuk1euro = Int32.Parse(Console.ReadLine());

            double bedrag = muntstuk2euro *2 + muntstuk1euro;

            Console.WriteLine($"Het totale bedrag is {bedrag} euro");
        }
    }
}
