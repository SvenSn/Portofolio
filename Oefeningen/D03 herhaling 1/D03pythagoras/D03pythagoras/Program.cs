namespace D03pythagoras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef de basis: ");
            int basis = int.Parse(Console.ReadLine());


            Console.Write("Geef de hoogte: ");
            int hoogte = int.Parse(Console.ReadLine()); 


            int schuineZijde = (basis*basis) + (hoogte*hoogte);

            Console.WriteLine($"De schuine zijde is {schuineZijde}");
        }
    }
}
