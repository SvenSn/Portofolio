namespace D12bertbeverzondertimespan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ticksPerMS = 10000;

            Console.WriteLine("Druk 2x op dezelfde toets zo snel mogelijk na elkaar.");

            char c1 = Console.ReadKey(true).KeyChar;
            long t1 = DateTime.Now.Ticks;

            char c2 = Console.ReadKey(true).KeyChar;    
            long t2  = DateTime.Now.Ticks;  

            if (c1 == c2)
            {
                long ticksDelta = t2 - t1;
                long tijdMS = ticksDelta / ticksPerMS;
                Console.WriteLine($"De tijd tussen de twee toetsen is: {tijdMS}");
            }
            else
            {
                Console.WriteLine("Niet dezelfde toets ingedrukt! ");
            }
        }
    }
}
