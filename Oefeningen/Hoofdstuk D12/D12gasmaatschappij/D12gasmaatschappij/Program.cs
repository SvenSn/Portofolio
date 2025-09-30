namespace D12gasmaatschappij
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef uw beginstand in. ");
            int beginStand = int.Parse(Console.ReadLine());

            Console.Write("Geef uw eindstand in. ");
            int eindStand = int.Parse(Console.ReadLine());  


            int verbruik = eindStand - beginStand;  

            if (verbruik < 0)
            {
                verbruik = (999999 - beginStand) + eindStand;
            }

            double prijs = 0;

            if (verbruik <= 1000)
            {
                prijs = verbruik * 0.34;
            }
            else
            {
                prijs = 1000 * 0.34;

                prijs += (verbruik - 1000) * 0.31;
            }


            Console.WriteLine($"De totale kostprijs is: {prijs:F2}");
        }
    }
}
