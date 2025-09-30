
using System.Security.Principal;

namespace D11encrypted
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string codewiel = "0ab1cd2ef3gh4ij5kl6m n7op8qr9st.uv,wx!yz?";


            string tekst = "a19z";
            string code = GetEncryptedCodeFor(tekst, codewiel, 5);

            Console.WriteLine("+ 5 " + tekst + "->" + code);
            // de output is  : + 5 a19z->2fv1

            tekst = "GROEN";
            Console.WriteLine("+ 5 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, 5));
            // de output is  : + 5 GROEN->GROEN

            tekst = "c# !";
            Console.WriteLine("+10 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, 10));
            // de output is  : +10 c# !->j#t2

            Console.WriteLine();

            tekst = "0allo?";
            Console.WriteLine("+ 1 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, 1));
            // de output is  : + 1 0allo?->ab66p0

            Console.WriteLine("+40 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, 40));
            // de output is  : +40 0allo?->?0kk7z

            Console.WriteLine("+41 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, 41));
            // de output is  : +41 0allo?->0allo?

            Console.WriteLine("-1 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, -1));
            // de output is  : - 1 0allo?->?0kk7z

            Console.WriteLine();

            Console.WriteLine("-10 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, -10));
            // de output is  : -10 0allo?->.ueeit

            Console.WriteLine("-40 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, -40));
            // de output is  : -40 0allo?->ab66p0

            Console.WriteLine("-41 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, -41));
            // de output is  : -41 0allo?->0allo?

            Console.WriteLine("-82 " + tekst + "->" + GetEncryptedCodeFor(tekst, codewiel, -82));
            // de output is  : -82 0allo?->0allo?
        }

        static string GetEncryptedCodeFor(string tekst, string codewiel, int offset)
        {
            string result = "";
           foreach (char c in tekst)
            {
                int index = codewiel.IndexOf(c);
                
                if (index == -1)
                {
                    result += c;
                }
                else
                {
                    int newIndex = (index + offset) % codewiel.Length;
                    if (newIndex < 0)
                    {
                        newIndex += codewiel.Length;
                    }
                    result += codewiel[newIndex];
                }
            }
           return result;
        }
    }
}
