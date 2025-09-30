namespace D12kortingplusbtw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Schrijf een programma dat de gebruiker vraagt om een prijs excl. BTW, een kortingspercentage en een BTW-percentage.
             * Je mag ervan uitgaan dat de gebruiker braafjes de gevraagde waarden invoert.
            Het programma toont de bedragen excl. BTW, korting, BTW en incl. BTW. De BTW wordt berekend nadat de korting al is afgetrokken.
            Je mag ervan uitgaan dat de bedragen altijd positief zijn en onder de 1000000 Euro blijven.
            Toon de bedragen netjes rechts uitgelijnd zoals op een kassaticket en gebruik bij het afronden MidpointRounding.AwayFromZero.*/

            Console.Write("Geef de prijs excl. BTW: ");
            double prijsExBTW = double.Parse(Console.ReadLine());


            Console.Write("Geef het kortingspercentage:  ");
            double kortingPercentage = double.Parse(Console.ReadLine());

            Console.Write("Geef BTW in %: ");
            double btwPercentage = double.Parse(Console.ReadLine());

            double korting = prijsExBTW * (kortingPercentage / 100.0);
            double kortingAfgerond = Math.Round(korting, 2, MidpointRounding.AwayFromZero);

            double prijsZonderKorting = prijsExBTW - kortingAfgerond;
            double btwBedrag = prijsZonderKorting * (btwPercentage / 100.0);
            double btwBedragAfgerond = Math.Round(btwBedrag, 2);

            double bedragIncBTW = prijsZonderKorting + btwBedragAfgerond;


            Console.WriteLine();
            Console.WriteLine($"prijs excl. BTW:{prijsExBTW,8:f2}");
            Console.WriteLine($"korting is:{kortingAfgerond,8:f2}");
            Console.WriteLine($"BTW:{btwBedragAfgerond,8:f2}");
            Console.WriteLine($"incl. BTW:{bedragIncBTW,8:f2}");

        }
    }
}
