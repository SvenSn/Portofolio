namespace D07_dotdotdot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Schrijf een programma dat de gebruiker om een tekst vraagt en vervolgens de tekst herhaalt maar een . achter elk karakter zet.

            Console.WriteLine("Geef een tekst:");
            string tekst = Console.ReadLine();

            // voor elke char van de tekst genaamd tekst een punt achter de char zetten
         foreach (char splitsen in tekst)
            {
                Console.Write($"{splitsen}.");
            }


        }
    }
}
