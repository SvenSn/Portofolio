namespace D07_klinkersenmedeklinkers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst vraagt en het aantal klinkers en medeklinkers weergeeft.

            Console.Write("Geef een tekst in: ");
            string input = Console.ReadLine();

            string klinkers = "aeiou";
            string medeKlinkers = "bcdfghjklmnpqrstvwxyz";


            int aantalKlinkers = 0;
            int aantalMedeKlinkers = 0;

            foreach (char c in  input)
            {
               char cLowerCase = char.ToLower(c);

                if (klinkers.Contains(cLowerCase))
                {
                    aantalKlinkers++;
                } else if (medeKlinkers.Contains(cLowerCase))
                {
                    aantalMedeKlinkers++;
                }
            }

            Console.WriteLine($"{aantalKlinkers} klinkers en {aantalMedeKlinkers} medeklinkers.");

        }
    }
}
