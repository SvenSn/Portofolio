namespace D04ohm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Wat wenst u te berekenen?(kies uit Spanning,Weerstand,Stroomsterkte) :");
            string keuze = Console.ReadLine();

            if(keuze == "Spanning")
            {
                Console.Write("Geef de stroomsterkte in: ");
                double stroomsterkte = double.Parse(Console.ReadLine());

                Console.Write("Geef de weerstand in: ");
                double weerstand = double.Parse(Console.ReadLine());

                double spanning = stroomsterkte * weerstand;

                Console.WriteLine($"De spanning is {spanning}");
            }
            else if (keuze == "Weerstand")
            {
                Console.Write("Geef de stroomsterkte in: ");
                double stroomsterkte = double.Parse(Console.ReadLine());

                Console.Write("Geef de spanning in: ");
                double spanning = double.Parse(Console.ReadLine());

                double weerstand = spanning * stroomsterkte;

                Console.WriteLine($"De weerstand is {weerstand}");
            }
            else if (keuze == "Stroomsterkte")
            {
                Console.Write("Geef de spanning in: ");
                double spanning = double.Parse(Console.ReadLine());

                Console.Write("Geef de weerstand in: ");
                double weerstand = double.Parse(Console.ReadLine());

                double stroomsterkte = spanning * weerstand;

                Console.WriteLine($"De stroomsterkte is {stroomsterkte}");
            }
        }
    }
}
