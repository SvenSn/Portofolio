using System.ComponentModel.Design;

namespace D04_ohm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Maak een programma dat vraagt aan de gebruiker wat zij/hij wenst te berekenen: Spanning, Weerstand of Stroomsterkte.
            Vraag vervolgens de twee andere waarden (indien de gebruiker "Spanning" kiest vraag je aan de gebruiker de stroomsterkte en de weerstand)
            en bereken de gewenste waarde.
            Hier kunnen we de 'wet van Ohm' gebruiken. U = I x R
            Hierin staat de letter U voor spanning, de I staat voor de stroomsterkte,
            en de R staat voor de weerstand. Of met ander woorden: Spanning = Stroomsterkte x Weerstand */

            Console.WriteLine("Wat wens je te bereken? kies uit spanning,weerstand of stroomsterkte");

            // string aanmaken de gekozen eenheid en value geven wat ingegeven word 
            string gekozenEenheid = Console.ReadLine();

            //if structuren op de basis van de gekozen eendheid maken 
            if (gekozenEenheid == "spanning")
            {
                Console.WriteLine("Wat is de stroomsterkte?");
                double stroomSterkte = double.Parse(Console.ReadLine());

                Console.WriteLine("Wat is de weerstand?");
                double weerstand = double.Parse(Console.ReadLine());

                double spanning = stroomSterkte * weerstand;
                Console.WriteLine($"De spanning is: {spanning}");
            }
            else if (gekozenEenheid == "stroomsterkte")
            {
                Console.WriteLine("Wat is de spanning?");
                double spanning = double.Parse(Console.ReadLine());

                Console.WriteLine("Wat is weerstand?");
                double weerstand = double.Parse(Console.ReadLine());

                double stroomsterkte = spanning / weerstand;

                Console.WriteLine($"De stroomsterkte is: {stroomsterkte}");
               
            }  
            else if ( gekozenEenheid == "weerstand")
            {
                Console.WriteLine("wat is de spanning?");
                double spanning = double.Parse(Console.ReadLine());

                Console.WriteLine("Wat is de stroomsterkte?");
                double stroomsterkte = double.Parse(Console.ReadLine());

                double weerstand = spanning / stroomsterkte;

                Console.WriteLine($"De weerstand is: {weerstand}");

            }
        }
    }
}
