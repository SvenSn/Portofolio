namespace D08volgordeomwisselen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoeveel namen wil u ingeven : ");
            string aantalAlsTekst = Console.ReadLine();
            int aantal = int.Parse(aantalAlsTekst);

            string[] namen = new string[aantal];

            for (int i = 0; i < namen.Length; i++)
            {
                Console.Write($"Geef naam {i + 1} : ");
                string naam = Console.ReadLine();
                namen[i] = naam;
            }

            Console.WriteLine("Namen voor wissel. " + string.Join(",", namen));

            for (int i = 0; i < namen.Length/2; i++)
            {
                string temp = namen[i];
                namen[i] = namen[namen.Length-1 -i];
                namen[namen.Length - 1 - i] = temp;
            }

            Console.WriteLine("Namen achter wissel. " + string.Join(", ",namen));
        }
    }
}
