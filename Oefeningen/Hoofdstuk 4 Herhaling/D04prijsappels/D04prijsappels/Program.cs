namespace D04prijsappels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker vraagt hoeveel kilo appels hij wenst aan te kopen. Druk vervolgens de prijs af.
            //De prijs bedraagt 3 euro per kilo, of 2,5 euro indien minstens 10 kilo wordt afgenomen, 2 euro bij een minimum aankoop van 20 kilo.


            Console.WriteLine("Hoevel kg appels wil je kopen? ");
            string kgAppelText = Console.ReadLine();
            int kgAppel = int.Parse(kgAppelText);

            double prijs;

            if (kgAppel < 10)
            {
                prijs = kgAppel * 3.0;
            }
            else if (kgAppel < 20)
            {
                prijs = kgAppel * 2.5;   
            }
            else
            {
                prijs = kgAppel * 2.0;
            }


            Console.WriteLine($"{kgAppel} kost {prijs} ");
        }
    }
}
