
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

            string output = "";
            for (int i = 0; i < aantal; i++)
            {
                output = output + tekst;    
            }

            return output;
        }
    }
}
