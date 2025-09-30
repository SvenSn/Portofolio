namespace D07aantalkeere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst in: ");
            string tekst = Console.ReadLine();
            int teller = 0;
            foreach (char c in tekst)
            {
                if (c == 'e' || c == 'E')
                {
                    teller++;
                }
            }

            Console.WriteLine($"Het char 'e' komt {teller} voor.");

        }
    }
}
