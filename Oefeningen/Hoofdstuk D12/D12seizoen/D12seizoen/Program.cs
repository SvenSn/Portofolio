namespace D12seizoen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een datum vraagt en aangeeft in welk weerkundig(!) seizoen deze datum valt.

            int jaar = DateTime.Now.Year;
            DateTime lente = new DateTime(jaar, 03, 01);
            DateTime zomer = new DateTime(jaar, 06, 01);
            DateTime herfst = new DateTime(jaar, 09, 01);
            DateTime winter = new DateTime(jaar, 12, 01);

            Console.Write("Geef een datum: ");
            string datumText = Console.ReadLine();


            System.Globalization.CultureInfo nlBe = new System.Globalization.CultureInfo("nl-BE");
            bool invoerOK = DateTime.TryParseExact(datumText,"dd/MM",nlBe,System.Globalization.DateTimeStyles.None, out DateTime datum);


            if (datum < lente || datum >= winter)
            {
                Console.WriteLine("Winter");
            }
            else if (datum < zomer)
            {
                Console.WriteLine("Lente");
            }
            else if (datum < herfst)
            {
                Console.WriteLine("Zomer");
            }
            else if (datum < winter)
            {
                Console.WriteLine("Herfst");
            }
        }
    }
}
