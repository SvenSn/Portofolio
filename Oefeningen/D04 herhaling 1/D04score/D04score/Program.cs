namespace D04score
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Wat is uw score in % ?: ");
            int score = int.Parse(Console.ReadLine());

            string scoreLetter = "";
            if(score > 82)
            {
                scoreLetter = "A";
            }
            else if (score > 67)
            {
                scoreLetter = "B";
            }
            else if (score > 52)
            {
                scoreLetter = "C";  
            }
            else if (score > 37)
            {
                scoreLetter = "D";  
            }
            else if (score > 22)
            {
                scoreLetter = "E";
            }
            else
            {
                scoreLetter = "F";
            }

            Console.WriteLine($"jouw score {score}% is de scoreletter {scoreLetter}.");
        }
    }
}
