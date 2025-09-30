namespace D12bertbevermettimespan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Druk 2x na elkaar op dezelfde toets , zo snel mogelijk slowpoke");

            char c1 = Console.ReadKey(true).KeyChar;
            DateTime dt1 = DateTime.Now;    


            char c2 = Console.ReadKey(true).KeyChar;
            DateTime d2 = DateTime.Now;

            if (c1==c2)
            {
                TimeSpan tussen = dt2 -dt1;
                Console.WriteLine($"De tijd tussen de twee toetsaanslagen was {tussen.TotalMilliseconds} ms");
            }
            else
            {
                Console.WriteLine("Dat waren 2 verschillende toetsen");
            }
        }
    }
}
