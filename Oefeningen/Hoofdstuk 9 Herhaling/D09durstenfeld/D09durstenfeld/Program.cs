namespace D09durstenfeld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kleuren = { "harten", "klaver", "schoppen", "ruiten" };
            string[] waarden = { "twee", "drie", "vier", "vijf", "zes", "zeven", "acht", "negen", "tien", "landbouwer", "dame", "koning", "aas" };

            string[] kaarten = new string[kleuren.Length * waarden.Length];

            int index = 0;

            foreach (string s in kleuren)
            {
                foreach (string t in waarden)
                {
                    kaarten[index] = s + " " + t;
                    index++;
                }
            }

            Random r = new Random();    

            for (int posNu = kaarten.Length-1;posNu >= 1;posNu--)
            {

                int posNext = r.Next(posNu+1);


                string temp = kaarten[posNu];
                kaarten[posNu] = kaarten[posNext];
                kaarten[posNext] = temp;
            }

            foreach (string kaart in kaarten)
            {
                Console.WriteLine(kaart);
            }




        }
    }
}
