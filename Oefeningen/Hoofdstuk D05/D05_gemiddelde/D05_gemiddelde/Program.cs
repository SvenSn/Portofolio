namespace D05_gemiddelde
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Schrijf een programma dat de gebruiker meermaals om een getal vraagt (totdat de gebruiker een -1 ingeeft).
            //Voor de eenvoud gaan we er hier van uit dat de gebruiker netjes getallen invoert, je hoeft hier niet op te controleren

            int getal = 0;
            int som = 0;
            int teller = 0;

            do
            {
                Console.WriteLine("Geef een getal in.");
                getal = Int32.Parse(Console.ReadLine());
                som += getal;
                teller++;
            }
            while (getal != -1);

            som -= getal;
            teller--;


            if (getal > 0)
            {
                
                double gemiddelde = Convert.ToDouble(som) / teller;
                Console.WriteLine($"Het gemiddelde is {gemiddelde}");

            }
            else
            {
                Console.WriteLine("Ingegeven getal niet toegestaan");
            }


            
        }
    }
}
