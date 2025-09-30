namespace D03cirkel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef de straal: ");
            double straal = double.Parse(Console.ReadLine());   


            double oppervlakte = straal * straal * Math.PI;
            double omtrek = (straal * Math.PI) * 2;

            Console.WriteLine($"de omtrek van de cirkel is {omtrek} en de oppervlakte {oppervlakte}");
        }
    }
}
