namespace D03_kleinermetmathmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef het eerste getal in.");
            int getal1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het tweede getal in.");
            int getal2 = Int32.Parse(Console.ReadLine());

            int kleinsteGetal = Math.Min(getal1, getal2);

            Console.WriteLine($"Het kleinste getal is : {kleinsteGetal}");
        }
    }
}
