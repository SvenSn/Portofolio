namespace D09_speelkaarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat alle 52 speelkaarten op het scherm weergeeft.

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

            foreach (string kaart in kaarten)
            {
                Console.WriteLine(kaart);
            }
        }
    }
}
