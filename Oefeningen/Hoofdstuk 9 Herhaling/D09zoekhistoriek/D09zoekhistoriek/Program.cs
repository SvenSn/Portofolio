namespace D09zoekhistoriek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] zoekhistoriek = { "Charlie Sheen", "Hot shots", "Winning", "Electrabel storing", "Geen elektriciteit" };



            do
            {
                Console.WriteLine(string.Join(": ", zoekhistoriek));


                Console.Write("nieuwe zoekterm: ");
                string input = Console.ReadLine();


                for (int i = 0;i < zoekhistoriek.Length-1; i++)
                {
                    zoekhistoriek[i] = zoekhistoriek[i + 1];
                }
                zoekhistoriek[zoekhistoriek.Length - 1] = input;


            }while (true);

        }
    }
}
