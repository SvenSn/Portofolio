namespace D02totalebedrag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef het aantal muntstukken van 2 euro : ");
            string muntstukken2 = Console.ReadLine();
            int muntstukken2Euro = int.Parse(muntstukken2);


            Console.Write("Geef het aantal muntstukken van 1 euro : ");
            string muntstukken1 = Console.ReadLine();
            int muntstukken1Euro = int.Parse(muntstukken1);
            

            int som = muntstukken2Euro * 2 + muntstukken1Euro;


            Console.WriteLine($"Het totale bedrag is {som}");





        }
    }
}
