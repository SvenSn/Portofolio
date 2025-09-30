namespace D09dierenwissen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] boerderijDieren = { "kip", "koe", "paard", "geit", "schaap" };

            while (true)
            {
                Console.WriteLine(string.Join(" ", boerderijDieren));


                Console.Write("Welk dier wil je verwijderen? ");
                string dier = Console.ReadLine();
                string dierKlein = dier.ToLower();

                for (int i = 0;i < boerderijDieren.Length;i++)
                {
                    if (boerderijDieren[i] == dierKlein)
                    {
                        boerderijDieren [i] = null;
                    }
                }

                

            }
        }
    }
}
