namespace D03kleinermetif
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een geheel getal in: ");
            int getal1 = int.Parse(Console.ReadLine());


            Console.Write("Geef nog een geheel getal in: ");
            int getal2 = int.Parse(Console.ReadLine());


            if (getal1 > getal2)
            {
                Console.WriteLine($"{getal2} is kleiner");
            }
            else if (getal1 < getal2)
            {
                Console.WriteLine($"{getal1} is kleiner.");
            }
            else
            {
                Console.WriteLine("Getallen zijn gelijk.");
            }
        }
    }
}
