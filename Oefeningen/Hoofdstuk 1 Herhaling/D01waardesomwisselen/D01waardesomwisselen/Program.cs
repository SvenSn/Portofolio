namespace D01waardesomwisselen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 13;

            int temp = b;
            b = a;
           a = temp;


            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
