namespace D06somveelvouden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal in : ");
            int getal1 = int.Parse(Console.ReadLine());

            Console.Write("Geef een getal in : ");
            int getal2 = int.Parse(Console.ReadLine());

            int som = 0;

            for (int i = getal1; i <= getal2; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    som += i;
                }
            }

            Console.WriteLine($"De som van tussenliggend 3-vouden en 5-vouden is {som}");
        }
    }
}
