namespace D12leeftijdindagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
           System.Globalization.CultureInfo nlbe = new System.Globalization.CultureInfo("nl-BE");


            Console.WriteLine("Geef uw geboortedatum in (dd/mm/jjjj)");
            string datumTekst = Console.ReadLine();

            DateTime geboorteDatum;

            bool invoerOK = DateTime.TryParseExact(datumTekst,"dd/MM/yyyy",nlbe,System.Globalization.DateTimeStyles.None, out geboorteDatum);

            DateTime vandaag = DateTime.Today;

            TimeSpan levend = vandaag - geboorteDatum;
            Console.WriteLine($"u bent {levend.TotalDays} dagen oud");
        }
    }
}
