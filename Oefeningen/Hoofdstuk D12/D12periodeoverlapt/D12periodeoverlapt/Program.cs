namespace D12periodeoverlapt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Opvragen start- en einddatum van periode 1...
            DateTime datum1 = Datum("startdatum van periode 1");
            DateTime datum2 = DatumVanaf(datum1, "einddatum van periode 1");

            // Opvragen start- en einddatum van periode 2...
            DateTime datum3 = Datum("startdatum van periode 2");
            DateTime datum4 = DatumVanaf(datum3, "einddatum van periode 2");

            // Controleren of deze periodes overlappen...
            string overlappen = "overlappen";
            if (!Overlapt(datum1, datum2, datum3, datum4)) overlappen += " niet";

            // Afprinten van de output...
            Console.Write($"Periode 1 ({PeriodeLabel(datum1, datum2)}) en periode 2 ({PeriodeLabel(datum3, datum4)}) {overlappen}.");
        }

        static DateTime Datum(string omschrijving)
        {
            return DatumVanaf(DateTime.MinValue, omschrijving);
        }
        
        static bool Overlapt(DateTime datum1,DateTime datum2,DateTime datum3,DateTime datum4)
        {
            DateTime start1 = datum1;
            DateTime eind1 = datum2;

            DateTime start2 = datum3;
            DateTime eind2 = datum4;

            return start2 <= eind1 && eind2 >= start1;
        }

        static DateTime DatumVanaf(DateTime datum1,string label)
        {
            DateTime datumInvoer;

            do
            {
                Console.WriteLine($"Geef een datum in voor {label}");
                string datumTekst = Console.ReadLine();


                System.Globalization.CultureInfo nlbe = new System.Globalization.CultureInfo("nl-BE");
                if (DateTime.TryParseExact(datumTekst, "dd/MM/yyyy", nlbe, System.Globalization.DateTimeStyles.None, out datumInvoer))
                {
                    if (datumInvoer >= datum1)
                    {
                        return datumInvoer ;
                    }
                }
                else
                {
                    Console.WriteLine($"De datum moet gelijk zijn of later zijn dan {datum1}");
                }
            }while (true);
        }

        static string PeriodeLabel(DateTime datum1,DateTime datum2)
        {
            string periode = datum1.ToString("dd/MM/yyyy") + " - " + datum2.ToString("dd/MM/yyyy");
            return periode;
        }
    
    }
}
