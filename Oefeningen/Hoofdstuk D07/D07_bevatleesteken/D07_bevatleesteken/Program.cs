namespace D07_bevatleesteken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om tekst vraagt en dat weergeeft of die tekst minstens 1 leesteken bevat.

            Console.Write("Geef een tekst: ");
            string tekst = Console.ReadLine();

            bool bevatLeesTeken = false;

            foreach (char c in tekst)
            {
                if (char.IsPunctuation(c))
                {
                    bevatLeesTeken = true;
                }

            }

            if (bevatLeesTeken)
            {
                Console.WriteLine("Er is minstens 1 leesteken gevonden");
            }
            else
            {
                Console.WriteLine("Geen leestekens gevonden in de tekst");
            }
        }
    }
}
