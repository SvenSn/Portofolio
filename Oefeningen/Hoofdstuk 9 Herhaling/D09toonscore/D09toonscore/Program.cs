namespace D09toonscore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vakken = { "Frans", "Engels", "Wiskunde", "Duits", "L.O." };
            int[] scores = { 34, 55, 20, 10, 80 };


            Console.Write("Geef een vak in. ");
            string invoer = Console.ReadLine();

            string invoerKlein = invoer.ToLower();
            int scoreVak = 0;

            for (int i = 0; i < vakken.Length; i++)
            {
                if (invoerKlein == vakken[i].ToLower())
                {
                    scoreVak = scores[i];
                }
            }

            Console.WriteLine($"De score voor dit vak is {scoreVak}/100");
        }
    }
}
