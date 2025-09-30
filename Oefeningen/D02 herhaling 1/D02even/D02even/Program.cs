namespace D02even
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een geheel getal in: ");
            int getal = Int32.Parse(Console.ReadLine());

            Console.Write("Het getal is ");
            if(getal % 2 == 0)
            {
                Console.Write("even.");
            }
            else
            {
                Console.Write("oneven.");
            }
        }
    }
}
