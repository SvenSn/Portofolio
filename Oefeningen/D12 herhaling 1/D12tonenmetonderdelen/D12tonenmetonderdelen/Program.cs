namespace D12tonenmetonderdelen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime vandaag = DateTime.Now;
            int dag = vandaag.Day;
            int maand = vandaag.Month;  
            int jaar = vandaag.Year;
            int uur  = vandaag.Hour;
            int minuut = vandaag.Minute;

            Console.WriteLine($"De datum van vandaag is {dag,2:D2}/{maand,2:D2}/{jaar,4:D4} en het is nu {uur,2:D2}u{minuut,2:D2}");


        }
    }
}
