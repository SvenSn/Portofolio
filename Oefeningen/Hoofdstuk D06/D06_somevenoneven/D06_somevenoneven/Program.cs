namespace D06_somevenoneven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om getallen vraagt totdat deze een negatief getal ingeeft


            int aantalEvenGetallen = 0;
            int aantalOddGetallen = 0;

            int getalInvoer = 0;

            int somEven = 0;
            int somOdd = 0;

            do
            {
                Console.WriteLine("Geef een getal in");
                getalInvoer = Int32.Parse(Console.ReadLine());

                if (getalInvoer % 2 == 0 && getalInvoer > 0)
                {
                    aantalEvenGetallen++;
                    somEven += getalInvoer;

                }
                else if (getalInvoer % 2 != 0 && getalInvoer > 0)
                {
                    aantalOddGetallen++;
                    somOdd += getalInvoer;
                }

            }
            while (getalInvoer >= 0);

            Console.WriteLine($"Het aantal even getallen is: {aantalEvenGetallen}");
            Console.WriteLine($"Het aantal oneven getallen is: {aantalOddGetallen}");
            Console.WriteLine($"De som van de even getallen is: {somEven}");
            Console.WriteLine($"De som van de oneven getallen is : {somOdd}");

        }
    }
}
