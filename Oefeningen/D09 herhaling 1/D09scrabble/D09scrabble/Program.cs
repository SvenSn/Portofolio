namespace D09scrabble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een woord in: ");
            string invoer = Console.ReadLine();

            string invoerGroot = invoer.ToUpper().Trim();

            char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int[] scores = new int[] {1,3,5,2,1,4,3,4,1,4,3,3,3,1,1,3,10,2,2,2,4,4,5,8,8,4};

            int som = 0;
            string uitvoer = "";

            foreach (char c in invoerGroot)
            {
               for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == c)
                    {
                        uitvoer += scores[i].ToString();
                        som += scores[i];
                    }
                }
            }

            string arrayuitvoer = string.Join("+",uitvoer.ToCharArray());

            Console.WriteLine($"Het woord {invoer} is {arrayuitvoer} = {som} waard.");
            
        }
    }
}
