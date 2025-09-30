namespace D07_tussenaccolades
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Schrijf een programma dat de gebruiker om een tekst vraagt en het deel ervan toont dat tussen accolades staat.
            //Indien er meerdere teksten tussen accolades staan, wordt enkel naar de eerste { en eerste } gekeken.

            Console.Write("Geef een tekst in: ");
            string invoer = Console.ReadLine();


            // ints maken met als value de index van de linkse en rechtse acolades dus positie waarin ze zich bevinden
            int links = invoer.IndexOf("{");
            int rechts = invoer.IndexOf("}");   


            //if maken met als condities waar de index van de linkse acolade verschillend is van -1,zelfde voor de rechtse acolade en zolang de links acolade zich voor de rechtse bevindt.

           if (links != -1 && rechts != -1 && links < rechts)
            {
                //int aanmaken met als value de lengte van de text tussen de index van de twee acolades dus rechts - links -1,-1 omdat anders de acolade meetelt
                int lengteText = rechts - links -1;

                //int voor de posities voor de tekst ertussen zonder de acolade dus links + 1 anders start het met de acolade
                int TextTussenAcolade = links +1;

                //string aanmaken met also value de substring tussen de twee acolades zonder de acolades zelf 
                string textTussen = invoer.Substring(TextTussenAcolade, lengteText);

                Console.WriteLine($"gevonden: {textTussen}");


            }
            else
            {
                Console.WriteLine("Niet gevonden");
            }

        }
    }
}
