namespace D12feestdagen
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int jaar = 2024;

            DateTime[] feestDagen =
            {
            new DateTime(2024,1,1),
            new DateTime(2024,5,1),
            new DateTime(2024,6,1),
            new DateTime(2024,6,9),
            new DateTime(2024,6,20),
            new DateTime(2024,8,21),
            new DateTime(2024,9,15),
            new DateTime(2024,11,1),
            new DateTime(2024,11,11),
            new DateTime(2024,12,25)

            };

            string[] feestDagenNaam =
            {
                "Nieuwjaar","Paasmaandag","Dag van de Arbeid","O.H. Hemelvaart","Pinkstermaandag","nationale feestdag","O.L.V. Hemelvaart",
                "Allerheiligen","Wapenstilstand","Kerstmis"
            };

            Console.Write($"Geef een datum in {jaar} in.");
            string datumTekst = Console.ReadLine();

            System.Globalization.CultureInfo nlbe = new System.Globalization.CultureInfo("nl-BE");
            DateTime datum;
            bool invoerOK = DateTime.TryParseExact(datumTekst,"dd/MM",nlbe,System.Globalization.DateTimeStyles.None, out datum);

            if (invoerOK)
            {
                if (datum.Year != jaar)
                {
                    datum = new DateTime(jaar, datum.Month, datum.Day);
                }

                bool feestdagGevonden = false;
                for (int i = 0; i < feestDagen.Length; i++)
                {
                    if (datum == feestDagen[i])
                    {
                        Console.WriteLine($"De datum is een feestdag, namelijk {feestDagenNaam[i]}");
                        feestdagGevonden = true;
                        break;
                    }
                }

                if (!feestdagGevonden)
                {
                    Console.WriteLine("Dit is geen feestdag");
                }
            }
            else
            {
                Console.WriteLine("Geen geldige datum ingegeven.");
            }

            
        }
    }
}
