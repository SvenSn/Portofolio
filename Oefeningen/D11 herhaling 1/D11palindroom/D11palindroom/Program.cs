
namespace D11palindroom
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Geef een tekst: ");
            string invoer = Console.ReadLine();
            string tekst = invoer.ToLower();


            IsPalindroom(tekst);
            Console.WriteLine(IsPalindroom(tekst));
        }

        private static bool IsPalindroom(string tekst)
        {
            bool isOK = true;
            if (tekst.Length <= 0)
            {
                isOK = false;
            }
            else
            {
                for (int i = 0; i < tekst.Length / 2; i++)
                {
                    if (tekst[i] != tekst[tekst.Length - 1 - i])
                    {
                        isOK &= false;
                    }
                    else
                    {
                        isOK = true;
                    }
                }
            }
            return isOK;
        }
    }
}
