namespace D03Absolutewaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal : ");
            string getalAlsTekst = Console.ReadLine();
            int getal = int.Parse(getalAlsTekst);

            int absoluteWaarde = Math.Abs(getal);
            

            Console.WriteLine("De absolute waarde is " + absoluteWaarde);
        }
    }
}
