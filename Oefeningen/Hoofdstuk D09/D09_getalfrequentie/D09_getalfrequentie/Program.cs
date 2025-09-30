namespace D09_getalfrequentie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om getallen vraag tussen 0 en 10 (grenzen inclusief) totdat de gebruiker 'stop' intypt (hoofdletterongevoelig).

            

            int[] getallen = new int[11];

            string invoer;


            do
            {
                Console.WriteLine("Geef een getal in [0,10].");
                invoer = Console.ReadLine();

                if (invoer.ToLower() != "stop")
                {
                    int getal = int.Parse(invoer);
                    getallen[getal]++;
                }
            } while (invoer.ToLower() != "stop");


            //output voor ieder getal kijken of her voorkomt en als het voorkomt uitschrijven hoeveel het voorkomt in de ingegeven getallen.

            for (int i = 0; i < getallen.Length; i++)
            {
                int getal = i;


                int duplicateGetallen = getallen[getal];
                if (duplicateGetallen > 0)
                {
                    Console.WriteLine($"Het getal {getal} kwam {duplicateGetallen} voor.");
                }
            }


           

        }
    }
}
