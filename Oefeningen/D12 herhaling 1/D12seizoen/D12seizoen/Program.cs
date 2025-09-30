namespace D12seizoen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int jaartal = DateTime.Now.Year;

            DateTime startLente = new DateTime(jaartal, 03, 01);
            DateTime startZomer = new DateTime(jaartal, 06, 01);
            DateTime startHerfst = new DateTime(jaartal, 09, 01);
            DateTime startWinter = new DateTime(jaartal, 12, 01);

            Console.Write("Geef een datum in: ");
            string datumText = Console.ReadLine();

            System.Globalization.CultureInfo nlbe = new System.Globalization.CultureInfo("nl-BE");

            DateTime datum;
            bool invoerOK = DateTime.TryParseExact(datumText,"dd/MM",nlbe , System.Globalization.DateTimeStyles.None, out datum);


            if (datum < startLente || datum >= startWinter)
            {
                Console.WriteLine("Winter");
            }
            else if (datum < startZomer)
            {
                Console.WriteLine("Lente");
            }
            else if (datum < startHerfst)
            {
                Console.WriteLine("Zomer");
            }
            else if (datum < startWinter)
            {
                Console.WriteLine("Herfst");
            }


        }
    }
}
