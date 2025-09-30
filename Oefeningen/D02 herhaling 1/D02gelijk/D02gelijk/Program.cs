namespace D02gelijk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef getal 1 in: ");
            int g1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef getal 2 in: ");
            int g2 = Int32.Parse(Console.ReadLine());


            Console.Write("Deze getallen zijn ");
            if (g1 == g2)
            {
                Console.Write("gelijk.");
            }else
            {
                Console.Write("verschillend.");
            }
        }
    }
}
