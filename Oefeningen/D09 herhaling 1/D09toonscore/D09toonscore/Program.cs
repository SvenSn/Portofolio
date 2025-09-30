namespace D09toonscore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vakken = { "Frans", "Engels", "Wiskunde", "Duits", "L.O." };
            int[] scores = { 34, 55, 20, 10, 80 };

            Console.Write("Geef de naam van het vak: ");
            string invoer = Console.ReadLine();

            string invoerKlein = invoer.ToLower().Trim();

            int score = 0;
            bool vakGevonden = true;

            for (int i = 0; i < scores.Length; i++)
            {
                if(vakken[i].ToLower().Trim() == invoerKlein)
                {
                    score = scores[i];
                    vakGevonden = true ;
                    break;
                }
                else
                {
                    vakGevonden=false;
                }
            }

            if (vakGevonden)
            {
                Console.WriteLine($"De score voor dit vak is {score}/100.");
            }
            else
            {
                Console.WriteLine("Geen score bekend.");
            }
            
        }
    }
}
