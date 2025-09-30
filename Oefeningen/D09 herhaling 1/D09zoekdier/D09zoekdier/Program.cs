namespace D09zoekdier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] boerderijDieren = { "kip", "koe", "paard", "geit", "schaap" };

            bool isBoerderijDier = true;

            Console.Write("Geef een dier in: ");
            string invoer = Console.ReadLine();

            string dier = invoer.ToLower().Trim();

            foreach (string dieren in boerderijDieren)
            {
                if(dieren == dier)
                {
                    isBoerderijDier = true;
                    break;
                }
                else
                {
                    isBoerderijDier = false;
                }
            }

            if (isBoerderijDier )
            {
                Console.WriteLine($"{dier} is een boerderijdier.");
            }
            else if (!isBoerderijDier)
            {
                Console.WriteLine($"{dier} is geen boerderijdier.");
            }
        }
    }
}
