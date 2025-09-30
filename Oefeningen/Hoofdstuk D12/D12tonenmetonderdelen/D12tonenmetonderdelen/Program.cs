namespace D12tonenmetonderdelen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Schrijf een programma dat de huidige datum toont, gebruik hierbij de verschillende onderdelen van een DateTime waarde opvraagt zoals
             * .Month en .Hour. Het aantal seconden en fractie van een seconde laat je achterwege.
               Bijvoorbeeld als het vandaag 12 november 2019 is om 10:49:50,567 toont het programma*/

            DateTime datumVandaag = DateTime.Now;

            int dag = datumVandaag.Day;
            int maand = datumVandaag.Month; 
            int jaar = datumVandaag.Year;
            int uur = datumVandaag.Hour;
            int minuut = datumVandaag.Minute;

            Console.WriteLine($"De datum vandaag is {dag}/{maand}/{jaar} en het is nu {uur}u{minuut}");
        }
    }
}
