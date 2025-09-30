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

            string temp = "";

            for (int teller = 0;  teller < namen.Length/2;teller++)
            {
                temp = namen[teller];
                namen[teller]= namen[namen.Length - teller - 1];
                namen[namen.Length - teller -1] = temp;
            }

            for (int index = 0; index < namen.Length; index++)
            {
                Console.WriteLine(namen[index]);
            }
        }
    }
}
