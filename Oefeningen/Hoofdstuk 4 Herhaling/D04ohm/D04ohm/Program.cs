namespace D04ohm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maak een programma dat vraagt aan de gebruiker wat zij/hij wenst te berekenen: Spanning, Weerstand of Stroomsterkte.


            Console.WriteLine("Wat wens je to berekenen? Kies uit spanning,weerstand en stroomsterkte.  ");
            string invoer = Console.ReadLine();

            string invoerKlein = invoer.ToLower();

            if (invoerKlein == "spanning")
            {
                Console.Write("Geef de stroomstertke. ");
                double stroomsterkte = double.Parse(Console.ReadLine());

                Console.Write("Geef de weerstand. ");
                double weerstand = double.Parse(Console.ReadLine());    


                double spanning = stroomsterkte * weerstand;
                Console.WriteLine($"De spanning is {spanning}");
            }
            else if (invoerKlein == "stroomsterkte")
            {
                Console.Write("Geef de spanning. ");
                double spanning = double.Parse(Console.ReadLine());

                Console.Write("Geef de weerstand. ");
                double weerstand = double.Parse(Console.ReadLine());

                double stroomsterkte = spanning / weerstand;

                Console.WriteLine($"De stroomsterkte is {stroomsterkte}");
            }
            else if (invoerKlein == "weerstand")
            {
                Console.Write("Geef de spanning. ");
                double spanning = double.Parse(Console.ReadLine());

                Console.Write("Geef de stroomsterkte. ");
                double stroomsterkte = double.Parse(Console.ReadLine());

                double weerstand = spanning / stroomsterkte;

                Console.WriteLine($"De weerstand is {weerstand}");
            }

        }
    }
}
