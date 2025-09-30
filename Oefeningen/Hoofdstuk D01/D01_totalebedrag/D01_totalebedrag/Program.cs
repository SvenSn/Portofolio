namespace D01_totalebedrag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biljettenVan10Euro = 7;
            int biljettenVan5Euro = 6;
            int muntstukkenVan2Euro = 5;
            int muntstukkenVan1Euro = 4;
            int muntstukkenVan50Cent = 3;
            // double inplaats van int gebruiken omdat het geen geheel getal is door de muntstukken van 50 cent. 
            // nieuwe variable maken en waarden toekennen.

            double totaalBedrag = biljettenVan10Euro * 10 +
                               biljettenVan5Euro * 5 +
                               muntstukkenVan2Euro * 2 +
                               muntstukkenVan1Euro +
                               muntstukkenVan50Cent * 0.5;


            Console.WriteLine(totaalBedrag);
        }
    }
}
