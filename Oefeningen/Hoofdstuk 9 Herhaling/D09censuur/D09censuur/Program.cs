namespace D09censuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] scheldwoorden = { "aapmens", "babi", "dwaas", "kaas", "kaffer", "flapdrol", "kip", "ezel", "gangster", "bitch" };

            Console.WriteLine("Geef een tekst in. ");
            string text = Console.ReadLine();
            string textKlein = text.ToLower();

            string censuur = textKlein;

            bool isGevonden = false;

            for (int i = 0; i < scheldwoorden.Length; i++)
            {
               

                foreach (string woord in scheldwoorden)
                {
                    if (textKlein.Contains(woord))
                    {
                        isGevonden = true;
                        int index = textKlein.IndexOf(woord);

                        if (index >= 0)
                        {
                            string censuurWoord = woord[0] + new string('*',woord.Length-2) + woord[woord.Length-1];

                            censuur = censuur.Replace(woord,censuurWoord);
                        }
                    }
                }
            }

            if (isGevonden)
            {
                Console.WriteLine($"De tekst {censuur} is onaanvaardbaar. ");
            }
            else
            {
                Console.WriteLine("De tekst is aanvaardbaard. ");
            }
        }
    }
}
