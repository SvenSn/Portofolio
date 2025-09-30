namespace D04_dagnummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Vraag de gebruiker om een dagnummer in het jaar (i.e. van 1 t.e.m. 365, dus geen schrikkeljaar). Het programma toont vervolgens in welke maand (als tekst) die dag zich bevindt.*/

            const int eindeJan = 31;
            const int eindeFeb = eindeJan + 28;
            const int eindeMarch = eindeFeb + 31;
            const int eindeApril = eindeMarch + 30;
            const int eindeMay = eindeApril + 31;
            const int eindeJune = eindeMay + 30;
            const int eindeJuly = eindeJune + 31;
            const int eindeAugust = eindeJuly + 31;
            const int eindeSep = eindeAugust + 30;
            const int eindeOct = eindeSep + 31;
            const int eindeNov = eindeOct + 30;
            const int eindeDec = eindeNov + 31;

            Console.WriteLine("Hoeveelste dag van het jaar is het?");
            int dag = Int32.Parse(Console.ReadLine());

            if (dag >= 1 && dag <= eindeDec)
            {
                if (dag <= eindeJan)
                {
                    Console.WriteLine("Januari");
                }
                else if (dag <= eindeFeb)
                {
                    Console.WriteLine("February");
                }
                else if (dag <= eindeMarch)
                {
                    Console.WriteLine("March");
                }
                else if (dag <= eindeApril)
                {
                    Console.WriteLine("April");
                }
                else if (dag <= eindeMay)
                {
                    Console.WriteLine("May");
                }
                else if (dag <= eindeJune)
                {
                    Console.WriteLine("June");
                }
                else if (dag <= eindeJuly)
                {
                    Console.WriteLine("July");
                }
                else if (dag <= eindeAugust)
                {
                    Console.WriteLine("August");
                }
                else if (dag <= eindeSep)
                {
                    Console.WriteLine("September");
                }
                else if (dag <= eindeOct)
                {
                    Console.WriteLine("October");
                }
                else if (dag <= eindeNov)
                {
                    Console.WriteLine("November");
                }
                else
                {
                    Console.WriteLine("December");
                }

            }
            else
            {
                Console.WriteLine("Geen geldige dag inegegeven");
            }
        }
    }
}
