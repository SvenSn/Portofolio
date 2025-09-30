namespace D09scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int[] numbers = { 1, 3, 5, 2, 1, 4, 3, 4, 1, 4, 3, 3, 3, 1, 1, 3, 10, 2, 2, 2, 4, 4, 5, 8, 8, 4 };


            Console.Write("Geef een woord: ");
            string woord = Console.ReadLine();
            string woordKlein = woord.ToLower();

            int[] scores = new int[woordKlein.Length];
            int som = 0;
            int teller = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                foreach (char c in woordKlein)
                {
                    if (c == letters[i])
                    {
                        scores[teller] = numbers[i];
                        teller++;
                    }
                }
            }

            for (int i = 0;i < scores.Length; i++)
            {
                som += scores[i];   
            }

            Console.WriteLine($"Het woord is " + string.Join("+",scores)+$"={som} punten waard.");

        }
    }
}
