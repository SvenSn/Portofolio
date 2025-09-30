namespace D12feestdagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int jaartal = 2019;

            DateTime[] feestDatums = {
    new DateTime(2019,1,1),
    new DateTime(2019, 4, 22),
    new DateTime(2019, 5, 1),
    new DateTime(2019, 5, 30),
    new DateTime(2019, 6, 10),
    new DateTime(2019, 7, 21),
    new DateTime(2019, 8, 15),
    new DateTime(2019, 11, 1),
    new DateTime(2019, 11, 11),
    new DateTime(2019, 12, 25)
};

            string[] feestNamen = {
    "Nieuwjaar",
    "Paasmaandag",
    "Dag van de Arbeid",
    "O.H.Hemelvaart",
    "Pinkstermaandag",
    "Nationale feestdag",
    "O.L.V.hemelvaart",
    "Allerheiligen",
    "Wapenstilstand",
    "Kerstmis"
};

            Console.Write($"Geef een datum in {jaartal} : ");
            string datumAlsTekst = Console.ReadLine();

            System.Globalization.CultureInfo nlBe = new System.Globalization.CultureInfo("nl-BE");
            DateTime datum;
            bool gelukt = DateTime.TryParseExact(datumAlsTekst, "dd/MM", nlBe, System.Globalization.DateTimeStyles.None, out datum);

            if (gelukt)
            {
                // corrigeer indien we het programma niet in het juiste jaar uitvoeren
                if (datum.Year != jaartal)
                {
                    datum = new DateTime(jaartal, datum.Month, datum.Day);
                }

                bool gevonden = false;
                for (int i = 0; i < feestDatums.Length; i++)
                {
                    DateTime feestDatum = feestDatums[i];
                    if (datum == feestDatum)
                    {
                        Console.WriteLine($"Dat is \"{feestNamen[i]}\" in {jaartal}");
                        gevonden = true;
                        break;
                    }
                }
                if (!gevonden)
                {
                    Console.WriteLine($"Dat is geen feestdag in {jaartal}");
                }
            }
            else
            {
                Console.WriteLine($"Ongeldige datum voor {jaartal}");
            }
        }
    }
}
