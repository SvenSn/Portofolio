namespace D09geenscheldwoorden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] scheldwoorden = {"aapmens","babi","dwaas","kaas","kaffer","flapdrol","kip","ezel","gangster","bitch"};

            Console.WriteLine("Geef een teskt in. ");
            string text = Console.ReadLine();
            string textKlein = text.ToLower();


            bool isGevonden = false;

            foreach(string woorden in scheldwoorden)
            {
                if (textKlein.Contains(woorden))
                {
                    isGevonden = true;
                    break;
                }
            }

            if (isGevonden)
            {
                Console.WriteLine("De tekst is onaanvaardbaar. ");
            }
            else
            {
                Console.WriteLine("De tekst is aanvaardbaard. ");
            }
        }
    }
}
