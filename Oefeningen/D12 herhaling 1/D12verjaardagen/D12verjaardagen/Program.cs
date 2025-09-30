namespace D12verjaardagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo nlBe = new System.Globalization.CultureInfo("nl-BE");
            const int aantalData = 10;

            int[] aantalPerMaand = new int[12];
            for (int i = 0; i < aantalData; i++)
            {
               
                Console.Write("Geef een geboortedatum : ");
                string datumAlsTekst = Console.ReadLine();

               
                DateTime datum;
                bool gelukt = DateTime.TryParseExact(datumAlsTekst, "dd/MM/yyyy", nlBe, System.Globalization.DateTimeStyles.None, out datum);

                
                int maandNummer = datum.Month;
                int index = maandNummer - 1;
                aantalPerMaand[index] = aantalPerMaand[index] + 1;
               
            }

            
            for (int index = 0; index < aantalPerMaand.Length; index++)
            {
                int maandNummer = index + 1;
                int aantal = aantalPerMaand[index];
                if (aantal > 0)
                {
                    Console.WriteLine($"In maand {maandNummer}, {aantal} verjaardag(en)");
                }
            }
        }
    }
}
