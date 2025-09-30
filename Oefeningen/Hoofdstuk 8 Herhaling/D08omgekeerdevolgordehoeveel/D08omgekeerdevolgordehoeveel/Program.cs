namespace D08omgekeerdevolgordehoeveel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Hoeveel namen wil je geven? ");
            string invoer = Console.ReadLine();
            int aantal = int.Parse(invoer);

            string[] namen = new string[aantal];

            for (int i = 0; i < aantal; i++)
            {
                Console.Write($"Geef naam {i+1} ");
                string naam = Console.ReadLine();

                namen[i] = naam;
            }

            for (int i = aantal-1;i >= 0; i--)
            {
                Console.WriteLine(namen[i]);
            }
        }
    }
}
