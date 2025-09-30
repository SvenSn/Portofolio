namespace D09_scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker vraagt om een woord in te typen en vervolgens de Scrabble woordscore toont.


            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int[] scores = { 1, 3, 5, 2, 1, 4, 3, 4, 1, 4, 3, 3, 3, 1, 1, 3, 10, 2, 2, 2, 4, 4, 5, 8, 8, 4 };

            Console.WriteLine("Geef een woord");
            string invoer = Console.ReadLine();
            int totaleScore = 0;
            string uitvoer = "+";


            for (int i = 0; i < letters.Length; i++)
            {
                foreach (char c in invoer.ToLower())
                {
                    if (c.ToString() == letters[i].ToLower())
                    {
                        uitvoer += "+" + scores[i];
                        totaleScore += scores[i];
                    }
                }
            }

            Console.WriteLine($"De totale score is {uitvoer} = {totaleScore}");
        }
    }
}
