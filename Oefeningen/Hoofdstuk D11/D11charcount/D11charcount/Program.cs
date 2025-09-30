
using static System.Net.Mime.MediaTypeNames;

namespace D11charcount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Herschrijf de oplossing van D07aantalkeere zodat het programma een method GetCharCount gebruikt.
            //Deze method telt hoe vaak een bepaald karakter in een string voorkomt en retourneert dit aantal.


            Console.WriteLine("Geef een tekst in: ");
            string tekst = Console.ReadLine();

            Console.WriteLine("Geef een karakter in: ");
            char c = char.Parse(Console.ReadLine());


            int aantal = GetCharCount(tekst,c);
            Console.WriteLine($" '{c}' komt {aantal} aantal keer voor in de tekst.");

           

        }

        private static int GetCharCount(string v1, char v2)
        {
            int eTeller = 0;

            foreach (char c in v1)
            {
                if (c == v2)
                {
                    eTeller++;
                }


            }

            return eTeller;
        }
    }
}
