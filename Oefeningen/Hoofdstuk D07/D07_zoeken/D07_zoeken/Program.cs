namespace D07_zoeken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst en een zoekwoord vraagt. Het programma toont hoe vaak het zoekwoord in de tekst voorkomt (hoofdletterongevoelig).


            Console.WriteLine("Geef een tekst in: ");
            string text = Console.ReadLine();

            Console.WriteLine("Geef een zoekterm in: ");
            string zoekTerm = Console.ReadLine();

            int aantalZoektermen = 0;
            // if zoland de zoekterm string niet leeg is 
            if (zoekTerm != "")
            {

                // string van text and zoekterm in lower cases zetten zodat het niet hoofdletter gevoelig is
                string textLower = text.ToLower();
                string zoekTermLower = zoekTerm.ToLower();

                //int met als value de index waar de zoekterm voorkomt de eerste keer
                int teller = textLower.IndexOf(zoekTermLower);

                //terwijl de teller verschillende is van -1 blijven loopen
                while (teller != -1)
                {
                    aantalZoektermen++;
                    // teller naar het zoeken de value van teller +1 geven omdat het geloopt heeft
                    int tellerNaZoeken = teller + 1;

                    // teller de value geven van de index na het zoeken van de zoekterm. dus bvb textlower is "aba" en als zoekterm "a", de eerste loop neemt dus de eerste "a"
                    //maar door tellernazoeken mee te geven gaat het zoeken na de index van de eerste "a" en zo verder...
                    teller = textLower.IndexOf(zoekTermLower, tellerNaZoeken);


                }



            }
           

            Console.WriteLine($"De zoekterm komt {aantalZoektermen} voor.");

        }
    }
}
