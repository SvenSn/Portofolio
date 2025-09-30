namespace D03cirkel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef de straal in. ");
            string straalText = Console.ReadLine();
            double straal = double.Parse(straalText);

            double omtrek = 2*Math.PI * straal;
            double oppervlakte = Math.PI * (Math.Pow(straal,2));

            Console.WriteLine($"De omtrek is {omtrek} en de oppervlakte is {oppervlakte}");


        }
    }
}
