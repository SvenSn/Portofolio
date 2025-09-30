
namespace D11palindroom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een woord: ");
            string invoer = Console.ReadLine();

            bool isPalinDroom = Palindroom(invoer);

            if (isPalinDroom)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
      
        }

        private static bool Palindroom(string? invoer)
        {
            string output = "";
            string check = invoer;

            foreach (char c in invoer)
            {
                output = c + output;
            }

            if (output == check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
