
namespace D11concataantalkeer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string output = ConcatAantalKeer("*-", 4);
            Console.WriteLine(output);
        }

        private static string ConcatAantalKeer(string tekst, int aantal)
        {
            string resultaat = "";

            for(int i = 0; i < aantal; i++)
            {
                resultaat = resultaat + tekst;
            }

            return resultaat;   
        }
    }
}
