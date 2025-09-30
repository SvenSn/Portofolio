
namespace D11geenscheldwoordenarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst : ");
            string tekst = Console.ReadLine();

            bool isOk = IsAanvaardbaar(tekst);

            if (isOk)
            {
                Console.WriteLine("Tekst is aanvaardbaar");
            }
            else
            {
                Console.WriteLine("Tekst is niet aanvaardbaar");
            }
        }

        private static bool IsAanvaardbaar(string? tekst)
        {
            string[] scheldwoorden = { "aapmens", "babi", "dwaas", "kaas", "kaffer", "flapdrol", "kip", "ezel", "gangster", "bitch" };
            foreach (string scheldwoord in scheldwoorden)
            {
                if (tekst.Contains(scheldwoord))
                {
                    return false;
                    
                }
            }
            return true;
        }
    }
}
