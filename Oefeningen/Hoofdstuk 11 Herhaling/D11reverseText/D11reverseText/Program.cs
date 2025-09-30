
namespace D11reverseText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst: ");
            string invoer = Console.ReadLine();

            string output = ReverseText(invoer);

            Console.WriteLine(output);
        }

        private static string ReverseText(string? invoer)
        {
            string text = "";

            foreach (char c in invoer)
            {
                text = c + text;    
            }

            return text;    
        }
    }
}
