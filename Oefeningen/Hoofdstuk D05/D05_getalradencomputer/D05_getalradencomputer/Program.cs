using System;

class Program
{
    static void Main()
    {

        //voorbeeld oplossing , nog zelf herschrijven zonder hulp --
        int laag = 1;
        int hoog = 100;
        int gokken = 0;

        Console.WriteLine("Denk aan een getal tussen 1 en 100.");

        while (true)
        {
            gokken++;
            int gok = (laag + hoog) / 2;
            Console.WriteLine($"Is het getal {gok}?");

            string reactie = Console.ReadLine().Trim();

            if (string.Equals(reactie, "juist", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Ik heb het getal geraden: {gok} in {gokken} gokken!");
                break;
            }
            else if (string.Equals(reactie, "hoger", StringComparison.OrdinalIgnoreCase))
            {
                laag = gok + 1;
            }
            else if (string.Equals(reactie, "lager", StringComparison.OrdinalIgnoreCase))
            {
                hoog = gok - 1;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Voer 'hoger', 'lager' of 'juist' in.");
            }
        }
    }
}

