
namespace D11reversetext
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst : ");
            string invoer = Console.ReadLine();

            ReverseText(invoer);
            Console.WriteLine(ReverseText(invoer));
        }

        private static string ReverseText(string tekst)
        {
            string resulaat = "";

            foreach (char c in tekst)
            {
                resulaat = c+ resulaat;
            }
            return resulaat;    
        }
    }
}
