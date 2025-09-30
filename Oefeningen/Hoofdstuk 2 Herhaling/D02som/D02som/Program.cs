namespace D02som
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Geef een geheel getal in. ");
            string getalText = Console.ReadLine();

            int getal1 = Int32.Parse(getalText);

            Console.Write("Geef een geheel getal in. ");
            string getalText2 = Console.ReadLine();

            int getal2 = Int32.Parse(getalText2);

            int som = getal1 + getal2;


            Console.WriteLine($"{getal1} plus {getal2} is gelijk aan {som}");
        }
    }
}
