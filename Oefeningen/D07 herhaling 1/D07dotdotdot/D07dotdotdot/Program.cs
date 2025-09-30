namespace D07dotdotdot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een tekst");
            string tekst = Console.ReadLine();

            foreach (char c in tekst)
            {
                Console.Write($"{c}.");
            }
        }
    }
}
