namespace D09_toonscore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vakken = { "Frans", "Engels", "Wiskunde", "Duits", "L.O." };
            int[] scores = { 34, 55, 20, 10, 80 };

            Console.WriteLine("Geef de naam van het vak");
            string tekst = Console.ReadLine();

            int score = 0;

            bool scoreGevonden = false;

            for (int i = 0; i < vakken.Length; i++)
            {
                string vak = vakken[i];

                if (vak.ToLower() == tekst.ToLower())
                {
                    score = scores[i];
                    scoreGevonden = true;
                    break;
                }
            }
            if (scoreGevonden)
            {
                Console.WriteLine($"Je hebt {score} voor het vak {tekst}");
            }
            else
            {
                Console.WriteLine("Vak niet gevonden");
            }

        }
    }
}
