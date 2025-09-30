namespace D12gasmaatschappij
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int max = 1000000;
            int verbruik = 0;
            double prijs;


            Console.Write("Geef de beginstand: ");
            string invoer = Console.ReadLine();
            int beginStand = int.Parse(invoer);

            Console.Write("Geef de einstand in: ");
            string eindstandText = Console.ReadLine();
            int eindStand = int.Parse(eindstandText);   

            if (eindStand < beginStand)
            {
                verbruik = (max-beginStand) + eindStand;
                
            }
            else
            {
                verbruik = eindStand - beginStand;
            }
            const double prijsEersteKub = 0.34;
            const int eersteKub = 1000;
            if (verbruik <= eersteKub)
            {
                prijs = verbruik * prijsEersteKub;
            } 
            else
            {
                prijs = (eersteKub * prijsEersteKub) + (verbruik - eersteKub) * 0.31;
                
            }


            Console.WriteLine($"De factuur bedraagd: {prijs,2:f}");
        }
    }
}
