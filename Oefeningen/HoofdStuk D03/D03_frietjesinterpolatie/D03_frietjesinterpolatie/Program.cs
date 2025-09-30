namespace D03_frietjesinterpolatie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een naam in: ");
            string naamEen = Console.ReadLine();

            Console.WriteLine("Geef een tweede naam in: ");
            string naamTwee = Console.ReadLine();

            Console.WriteLine("Geef een gerecht: ");
            string gerecht = Console.ReadLine();

            Console.WriteLine($"{naamEen} en {naamTwee} eten graag {gerecht}");


        }
    }
}
