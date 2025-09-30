namespace D09_durstenfeld
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] kleuren = { "harten", "klaver", "schoppen", "ruiten" };
            string[] waarden = { "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "landbouwer", "dame", "koning", "aas" };


            string[] kaarten = new string[52];


            int i = 0;

            foreach (string k in kleuren)
            {
                foreach (string w in waarden)
                {
                    kaarten[i] = k + " " + w;
                    i++;
                }
            }

        // random aanroepen met als naam r voor simpelheid
           Random r = new Random(); 

            //for loop van de positie nu tot aan het einde van de array kaarten zijn lengte -1 aftellend
            for (int positieNu = kaarten.Length-1; positieNu >=1; positieNu--)
            {
                //volgende positie declaleren als random.next met als parameter positieNu +1 zodat het niet dezelfde positie kan geven
                int positieNext = r.Next(positieNu+1);

                // swappen van de 2 posities met een tijdelijke string 
                string temp = kaarten[positieNu];
                kaarten[positieNu] = kaarten[positieNext];
                kaarten[positieNext] = temp;

            }

            foreach (string kaart in kaarten)
            {
                Console.WriteLine(kaart);
            }



        }
    }
}
