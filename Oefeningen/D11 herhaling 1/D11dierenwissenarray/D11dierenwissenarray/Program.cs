
namespace D11dierenwissenarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] boerderijDieren = { "kip", "koe", "paard", "geit", "schaap" };

            do
            {
                toonDieren(boerderijDieren);
                wisDierVanGebruiker(boerderijDieren);
            } while (true);
        }

        private static void wisDierVanGebruiker(string[] boerderijDieren)
        {
            // vraag om een dier en bepaal de positie
            Console.Write("Welk dier wil je verwijderen : ");
            string tewissenDier = Console.ReadLine();
            int index = Array.IndexOf(boerderijDieren, tewissenDier);

            if (index != -1)
            {
                // wis dier
                boerderijDieren[index] = null;
            }
        }

        private static void toonDieren(string[] boerderijDieren)
        {
            // toon alle dieren
            foreach (string dier in boerderijDieren)
            {
                if (dier == null)
                {
                    // toon GEWIST als we een null tegenkomen
                    Console.Write("GEWIST ");
                }
                else
                {
                    Console.Write(dier + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
