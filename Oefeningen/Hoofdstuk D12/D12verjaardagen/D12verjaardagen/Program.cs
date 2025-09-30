namespace D12verjaardagen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo nlBe = new System.Globalization.CultureInfo("nl-BE");
            const int aantalDatums = 10;


            int[] aantalPerMaand = new int[12];
            for (int i = 0; i < aantalDatums; i++)
            {

                Console.Write("Geef een geboortedatum in:  ");
                string geboorteDatumText = Console.ReadLine();

                bool invoerOk = DateTime.TryParseExact(geboorteDatumText, "dd/MM/yyyy", nlBe, System.Globalization.DateTimeStyles.None, out DateTime datum);

                //op bij bvb 23/12/1997 word de value op index 11 dus maand - 1 naar 1 gebracht
                int maand = datum.Month;
                int index = maand - 1;
                aantalPerMaand[index]++;
            }


            for (int i = 0;i < aantalPerMaand.Length;i++)
            {
                int maand = i + 1;
                int aantal = aantalPerMaand[i];
                if (aantal > 0)
                {
                    Console.WriteLine($"in maand {maand}, {aantal} verjaardagen");
                }
            }

        }
    }
}
