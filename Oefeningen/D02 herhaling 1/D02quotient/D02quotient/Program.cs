namespace D02quotient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Deeltal?: ");
            double deeltal = double.Parse(Console.ReadLine());


            Console.Write("Deler?: ");
            double deler = double.Parse(Console.ReadLine());

            double resultaat = deeltal / deler;

            Console.WriteLine($"Quotient: {resultaat}");
        }
    }
}
