namespace D09zoekdier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] boerderijDieren = { "kip", "koe", "paard", "geit", "schaap" };

            Console.Write("Geef een dier in. ");
            string dier = Console.ReadLine();

            string dierKlein = dier.ToLower();


            bool isBdier = false;
            

           foreach (string dieren  in boerderijDieren)
            {
                if (dierKlein == dieren.ToLower())
                {
                    isBdier = true;
                    break;
                }
            }
            

           if (isBdier)
            {
                Console.WriteLine($"{dierKlein} is een boerderij dier. ");
            }
           else
            {
                Console.WriteLine("Het is geen boerderijdier.");
            }
        }
    }
}
