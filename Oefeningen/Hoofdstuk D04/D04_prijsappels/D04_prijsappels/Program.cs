namespace D04_prijsappels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Schrijf een programma dat de gebruiker vraagt hoeveel kilo appels hij wenst aan te kopen. 
             * Druk vervolgens de prijs af.
             * De prijs bedraagt 3 euro per kilo,
             * of 2,5 euro indien minstens 10 kilo wordt afgenomen, 2 euro bij een minimum aankoop van 20 kilo. */


            Console.WriteLine("Hoeveel kg appels wil je kopen?");
            int appelsKg = Int32.Parse(Console.ReadLine());


            // double voor prijs initialiseren genaamd prijsAppels
            double prijsAppels;

            // if structuren maken voor de verschillende prijzen van de appels op basis van het aantal kg gekochte appels
            if (appelsKg >= 20)
            {
                prijsAppels = appelsKg * 2;
            }
            else
            {
                if (appelsKg >= 10)
                {
                    prijsAppels = appelsKg * 2.5;
                }
                else
                {
                    prijsAppels = appelsKg * 3;
                }
            }

            //output geven van het aantal gekochte appels in kg en prijs voor dit aantal appelen
            //(ter zelf controle appels in kg bijzetten)
            Console.WriteLine($"Het aantal kg aangekochte appels bedraagt: {appelsKg} en de prijs is {prijsAppels}");
        }
    }
}
