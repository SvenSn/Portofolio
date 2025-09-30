namespace D12kortingplusbtw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een bedrag excl. BTW (2 cijfers na de komma) : ");
            double bedrag = double.Parse(Console.ReadLine());

            Console.Write("Geef de korting (in %) : ");
            double korting = double.Parse(Console.ReadLine());
            double kortingPercentage = korting / 100.0;

            Console.Write("Geef het BTW-tarief (in %) : ");
            double BTW = double.Parse(Console.ReadLine());
            double BTWPercentage = BTW / 100.0;

            double kortingBedrag = bedrag * kortingPercentage;
            double bedragExKorting = bedrag - kortingBedrag;

            double bedragBTW = bedragExKorting * BTWPercentage;
            double bedragIncBTW = bedrag + bedragBTW;

            Console.WriteLine($"excl. BTW : {bedrag}");
            Console.WriteLine($"korting :  : {kortingBedrag,2:f}");
            Console.WriteLine($"BTW : {bedragBTW,2:f}");
            Console.WriteLine($"Incl. BTW : {bedragIncBTW,2:f}");
        }
    }
}
