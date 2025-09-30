namespace D02gemiddelde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een kommagetal in: ");
            double g1 = double.Parse(Console.ReadLine());

            Console.Write("Geef een kommagetal in: ");
            double g2 = double.Parse(Console.ReadLine());

            Console.Write("Geef een kommagetal in: ");
            double g3 = double.Parse(Console.ReadLine());


            double gemiddelde = (g1 + g2 + g3) / 3;

            Console.WriteLine($"Het gemiddelde is : {gemiddelde}");
        }
    }
}
