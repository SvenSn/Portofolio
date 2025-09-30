namespace D09speelkaarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kleuren = { "harten", "klaver", "schoppen", "ruiten" };
            string[] waarden = { "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "landbouwer", "dame", "koning", "aas" };

            string[] kaarten = new string[kleuren.Length*waarden.Length];


            int index = 0;
            foreach (string kaart in kleuren)
            {
                foreach(string waarde in waarden)
                {
                    kaarten[index] = kaart + " " + waarde;
                    index++;
                }
            }


            foreach (string kaartprint in kaarten)
            {
                Console.WriteLine(kaartprint);
            }
        }
    }
}
