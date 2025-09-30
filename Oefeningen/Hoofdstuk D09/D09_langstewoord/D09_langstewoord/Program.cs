namespace D09_langstewoord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst vraagt en vervolgens toont hoeveel woorden erin voorkomen en wat het langste woord is.
            //Indien er meerdere woorden zijn van die lengte, toon dan het eerste.
            //Je mag ervan uitgaan dat woorden enkel door spaties, komma’s, punten, uitroeptekens en vraagtekens gescheiden worden.

            Console.WriteLine("Geef een teskt in.");
            string invoer = Console.ReadLine();

            char[] leesTekens = {' ',',','.','!','?' };

            int aantalwoorden = 0;
            string langsteWoord = "";

            string[] woorden = invoer.Split(leesTekens);   

            foreach (string woord in woorden)
            {
                if (woord != "")
                {
                    aantalwoorden++;
                    if (woord.Length > langsteWoord.Length)
                    {
                        langsteWoord = woord;
                    }
                }
            }

            Console.WriteLine($"aantal woorden: {aantalwoorden} ");
            Console.WriteLine($"Het langste woord is: {langsteWoord}");

        }
    }
}
