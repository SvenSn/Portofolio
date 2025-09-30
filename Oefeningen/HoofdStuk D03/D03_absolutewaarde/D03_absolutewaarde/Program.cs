namespace D03_absolutewaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef en getal in.");
            int getal = int.Parse(Console.ReadLine());

            int absoluteWaarde = Math.Abs(getal);

            Console.WriteLine($"De absolute waarde van {getal} is {absoluteWaarde}");
        }
    }
}
