namespace D05grootstegetalenaantal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int aantalGrootste = 0;
            int getal = 0;
            int grootste = 0;
            int teller = 0;

            do
            {
                Console.Write("Geef een getal (-1 om te stoppen) : ");
                getal = int.Parse(Console.ReadLine());

                if (getal != -1)
                {
                    teller++;
                    if (teller == 1 || getal > grootste)
                    {
                        grootste = getal;
                        aantalGrootste = 1;
                    }else if (grootste == getal)
                    {
                        aantalGrootste++;
                    }
                }

            } while (getal != -1);

            if( teller != 0)
            {
                Console.WriteLine($"het grootste getal was {grootste} en kwam {aantalGrootste} aantal keer voor. ");

            }else
            {
                Console.WriteLine("Geen geldige getallen ingegeven.");
            }
        }
    }
}
