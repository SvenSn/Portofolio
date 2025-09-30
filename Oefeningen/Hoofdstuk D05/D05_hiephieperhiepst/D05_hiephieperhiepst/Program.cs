namespace D05_hiephieperhiepst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoe oud wordt de jarige : ");
            int leeftijd = int.Parse(Console.ReadLine());

            int jaar = 1;
            while (jaar <= leeftijd)
            {
                Console.WriteLine("Hiep hiep hiep, hoera!");
                jaar++;
            }
            if (jaar != leeftijd + 1)
            {
                Console.WriteLine("Nog een keer !");
            }
        }
    }
}
