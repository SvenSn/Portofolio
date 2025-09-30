using System.ComponentModel.DataAnnotations;

namespace D16zoektermenachteraan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int aantal = 5;

            List<string> zoekterms = new List<string> { "Charlie Sheen", "Hot shots", "Winning", "Electrabel storing", "Geen elektriciteit" };

            while (true)
            {
                string zoektermen = string.Join(":", zoekterms);



                Console.WriteLine(zoektermen);


                Console.Write("Nieuwe zoekterm ");
                string invoer = Console.ReadLine();

                zoekterms.Add(invoer);

                if (zoekterms.Count > aantal )
                {
                    zoekterms.RemoveAt(0);  
                } 

            }

        }
    }
}
