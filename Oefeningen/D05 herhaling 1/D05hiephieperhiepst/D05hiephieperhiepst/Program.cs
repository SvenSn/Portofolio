namespace D05hiephieperhiepst
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
                if  (jaar != leeftijd)
                {
                    Console.WriteLine("Nog een keer!");
                }
                jaar++;
            }
        }
    }
}
