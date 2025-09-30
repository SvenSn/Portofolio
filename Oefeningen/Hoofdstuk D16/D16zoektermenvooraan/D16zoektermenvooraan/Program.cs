namespace D16zoektermenvooraan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int aantal = 5;

            List<string> zoektermen = new List<string> { "Geen elektriciteit", "Electrabel storing", "Winning", "Hot shots", "Charlie Sheen" };

            while (true)
            {
                

                string zoekterms = string.Join(":",zoektermen);

                Console.WriteLine(zoekterms);

                Console.Write("Nieuwe zoekterm hier. ");

                string invoer = Console.ReadLine(); 

                zoektermen.Insert(0, invoer);

                if (zoektermen.Count > aantal)
                {
                    zoektermen.RemoveAt(aantal);
                }


               
            }
        }
    }
}
