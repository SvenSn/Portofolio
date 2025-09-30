namespace D12palindroom
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Geef een tekst : ");
            string tekst = Console.ReadLine();

            Console.WriteLine(IsPalindroom(tekst));
        }

        static bool IsPalindroom(string tekst)
        {
            string reverse = ReverseText(tekst);
            if (tekst == reverse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string ReverseText(string tekst)
        {
            string result = "";
            foreach (char c in tekst)
            {
                result += c.ToString();
            }
            return result;
        }
    }
}
