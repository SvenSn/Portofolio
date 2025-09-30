
namespace D11charcount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int aantal = GetCharCount("This is a local shop, for local people; there's nothing for you here..", 'o');
            Console.WriteLine(aantal);
        }

        private static int GetCharCount(string tekst, char c)
        {
            int teller = 0;

            foreach (char ch in tekst)
            {
                if (ch == c)
                {
                    teller++;
                }
            }
            return teller;
        }
    }
}
