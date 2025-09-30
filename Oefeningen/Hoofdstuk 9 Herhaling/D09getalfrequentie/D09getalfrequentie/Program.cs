namespace D09getalfrequentie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om getallen vraag tussen 0 en 10 (grenzen inclusief) totdat de gebruiker 'stop' intypt (hoofdletterongevoelig).

            int[] aantal = new int[11];


            string invoer;

            do
            {
                

                Console.WriteLine("Geef een getal is [0,10]: ");
                invoer = Console.ReadLine();

                if (invoer.ToLower() != "stop")
                {
                    int getal = int.Parse(invoer);
                    aantal[getal]++;
                }

            } while (invoer.ToLower() != "stop");

            for (int i = 0; i < aantal.Length; i++)
            {
                int getal = i;

                int aantalKeer = aantal[getal];

                if (aantalKeer > 0)
                {
                    Console.WriteLine($"Het getal {getal} kwam {aantalKeer} voor. ");
                }
            }
        }
    }
}
