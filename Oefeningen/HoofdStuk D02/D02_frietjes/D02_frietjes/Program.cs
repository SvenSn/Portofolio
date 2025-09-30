namespace D02_frietjes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Schrijf een programma dat de gebruiker om 2 namen (bv. Jan en Mieke) 
             * alsook een gerecht (bv. frietjes) vraagt en vervolgens Jan en Mieke eten graag frietjes. op de console zet.*/


            Console.WriteLine("Geef een naam");
            string eersteNaam = Console.ReadLine();

            Console.WriteLine("Geef een tweede naam");
            string tweedeNaam = Console.ReadLine();

            Console.WriteLine("Geef een gerecht in: ");
            string gerecht = Console.ReadLine();

            Console.WriteLine($"{eersteNaam} en {tweedeNaam} eten graag {gerecht}.");




        }
    }
}
