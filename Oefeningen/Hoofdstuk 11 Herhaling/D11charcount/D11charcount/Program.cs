
namespace D11charcount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int aantal = GetCharCount("This is a local shop, for local people; there's nothing for you here..", 'o');

            Console.WriteLine($"'o' komt {aantal} keer voor");
        }

        private static int GetCharCount(string tekst, char teken)
        {
            int aantal = 0;
            foreach (char c in tekst)
            {
                if (c == teken || c == teken)
                {
                    aantal++;
                }
            }
            return aantal;
        }
    }
}
