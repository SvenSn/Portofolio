namespace D03kleinermetmathmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een geheel getal in. ");
            int getal1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Geef nog een geheel getal in. ");
            int getal2 = int.Parse(Console.ReadLine());

            int kleinsteGetal = Math.Min(getal1,getal2);

            Console.WriteLine($"{kleinsteGetal} is kleiner.");
        }
    }
}
