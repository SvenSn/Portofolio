namespace D12bertbeverzondertimespan
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int ticksMillisecond = 10000;
            Console.WriteLine("Druk 2x na elkaar op dezeflde toets, zo snel mogelijk ");


            char press1 = Console.ReadKey(true).KeyChar;
            long pressTick1 = DateTime.Now.Ticks;

            char press2 = Console.ReadKey(true).KeyChar;    
            long pressTick2 = DateTime.Now.Ticks;


            if (press1 == press2)
            {
                long verschilTicks = pressTick2 - pressTick1;
                long msVerschil = verschilTicks / ticksMillisecond;

                Console.WriteLine($"De tijd tussen de 2 presses is: {msVerschil}ms");
            }
            else
            {
                Console.WriteLine("Niet 2 keer dezelfde toets ingedrukt");
            }
        }
    }
}
