namespace D07_Cirkel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef de straal van een cirkel : ");
            string straalAlsTekst = Console.ReadLine();
            double straal = double.Parse(straalAlsTekst);

            double omtrek = 2 * Math.PI * straal;
            double oppervlakte = Math.PI * Math.Pow(straal, 2);

            Console.WriteLine($"De omtrek is {omtrek, 0:f3}.");
            Console.WriteLine($"De oppervlakte is {oppervlakte, 0:f3}.");


        }
    }
}
