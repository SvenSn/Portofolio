namespace D01_waardesomwisselen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 13;

            // 3rd variabele aanmaken en value van een van de eerste twee geven anders kan je deze niet van value swappen
            int c = a;
            a = b;
            b = c;
           




            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
