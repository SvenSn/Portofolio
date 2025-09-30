namespace D12leeftijdinjaren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef uw geboortedatum in (dd/mm/jjjj).");
            string datumAlsText = Console.ReadLine();

            System.Globalization.CultureInfo nlbe = new System.Globalization.CultureInfo("nl-BE");


            DateTime geboorteDatum;
            bool invoerOK = DateTime.TryParseExact(datumAlsText,"dd/MM/yyyy",nlbe,System.Globalization.DateTimeStyles.None,out geboorteDatum);
            
            DateTime vandaag = DateTime.Today;

            int leeftijdJaren = vandaag.Year - geboorteDatum.Year;


            DateTime nietVerjaard = new DateTime(vandaag.Year, geboorteDatum.Month, geboorteDatum.Day);
            
            if (nietVerjaard > vandaag)
            {
                leeftijdJaren--;
            }
            
            string vandaagText = vandaag.ToString("dd/MM/yyyy");
            Console.WriteLine($"vandaag is het {vandaagText}, dus u bent {leeftijdJaren} jaar oud.");

        }
    }
}
