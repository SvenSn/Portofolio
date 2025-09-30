namespace D07cirkel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef de straal in: ");
            double straal = double.Parse(Console.ReadLine());

            double omtrek = 2 * Math.PI * straal;
            double oppervlakte = Math.PI * Math.Pow(straal, 2);

            Console.WriteLine($"De omtrek is: {omtrek,0:f3}");
            Console.WriteLine($"De omtrek is: {oppervlakte,0:f3}");


        }
    }
}
