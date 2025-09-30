namespace D07achterstevoren
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst: ");
            string invoer = Console.ReadLine();

            for (int i = invoer.Length-1; i >= 0; i--)
            {
                char c = invoer[i];
                Console.Write(c);
            }
        }
    }
}
