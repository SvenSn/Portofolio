namespace D09_dagnummernaarmaand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker vraagt om een dagnummer in het jaar (i.e. van 1 t.e.m. 365, dus geen schrikkeljaar).
            //Het toont vervolgens in welke maand (als tekst) die dag zich bevindt.

            int[] aantalDagen = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] maandNamen = { "Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December" };

            Console.WriteLine("Geef een nummer in van 1 tot 365.");
            int dagnummer = Int32.Parse(Console.ReadLine());

            string maand = "Geen";

            int totaleDagen = 0;


            for (int i = 0; i < aantalDagen.Length; i++)
            {
                totaleDagen += aantalDagen[i];

                if (dagnummer <= totaleDagen)
                {
                    maand = maandNamen[i];
                    break;
                }
            }


            Console.WriteLine($"De maand is {maand}");

        }
    }
}
