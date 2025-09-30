namespace D02_gelijk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om 2 gehele getallen vraagt en ofwel meldt Ze zijn gelijk. ofwel Ze zijn verschillend..

            Console.WriteLine("Geef het eerste geheel getal in:");
            string geheelGetalTekst1 = Console.ReadLine();   
            int geheelGetal1 = Int32.Parse(geheelGetalTekst1);

            Console.WriteLine("geef het tweede gehele getal in:");
            string geheelGetalTekst2 = Console.ReadLine();
            int geheelGetal2 = Int32.Parse(geheelGetalTekst2);

            Console.WriteLine("Het getal is ");

            if (geheelGetal1 == geheelGetal2) 
            {
                Console.WriteLine("gelijk.");
            }
            else
            {
                Console.WriteLine("verschillend.");
            }

        }
    }
}
