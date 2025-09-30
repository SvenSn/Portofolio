namespace D09durstenfeld
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

           
            Random r = new Random();

            
            for (int positieNu = kaarten.Length - 1; positieNu >= 1; positieNu--)
            {
                
                int positieNext = r.Next(positieNu + 1);

               
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
