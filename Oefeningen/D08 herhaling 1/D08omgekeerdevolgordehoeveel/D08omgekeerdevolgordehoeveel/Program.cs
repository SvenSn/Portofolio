namespace D08omgekeerdevolgordehoeveel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoeveel namen wil je ingeven? ");
            int aantal = int.Parse(Console.ReadLine());


            string[] namen = new string[aantal];


            for (int i = 0; i < namen.Length; i++)
            {
                Console.Write($"Geef naam {i+1} in: ");
                namen[i] = Console.ReadLine();
            }

            for (int index = namen.Length - 1; index >= 0; index--)
            {
                Console.WriteLine(namen[index]);
            }
        }
    }
}
