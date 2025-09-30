namespace D09geenscheldwoorden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] scheldWoorden = { "doos", "dwaas", "geit", "boef", "klapluis", "klojo", "gluiper", "heks", "broodaap", "choco" };



            Console.Write("Geef een tekst in: ");
            string invoer = Console.ReadLine();

            string invoerKlein = invoer.ToLower().Trim();
            bool isScheldwoord = true;

            foreach(string s in scheldWoorden)
            {
                if (invoerKlein.Contains(s))
                {
                    isScheldwoord = true;
                    break;
                }
                else
                {
                    isScheldwoord = false;
                }
            }

            if (isScheldwoord)
            {
                Console.WriteLine("Deze tekst bevat een scheldwoord.");
            }
            else
            {
                Console.WriteLine("Deze tekst bevat geen scheldwoord.");
            }

        }
    }
}
