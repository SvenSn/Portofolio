namespace D07bevatleesteken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst: ");
            string invoer = Console.ReadLine();

            int teller = 0;

            foreach (char c in invoer)
            {
                if (char.IsPunctuation(c))
                {
                    teller++;
                }
            }

            Console.WriteLine($"Er komen {teller} leestekens voor.");
        }
    }
}
