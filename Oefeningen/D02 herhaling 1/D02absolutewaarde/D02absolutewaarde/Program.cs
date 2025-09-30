namespace D02absolutewaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een geheel getal: ");
            int getal = int.Parse(Console.ReadLine());  

               if (getal >= 0)
            {
                Console.WriteLine(getal);
            }else
            {
                Console.WriteLine($"{-1 * getal}");
            }
        }
    }
}
