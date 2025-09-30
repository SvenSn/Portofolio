namespace D05_tafelsvan7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Maak een programma dat het resultaat van de vermenigvuldiging van het getal 7 met de factoren 1 tot en met 10 gaat weergeven.
            //Doe dit aan de hand van een herhalingsstructuur, werk met een do while statement.


            int basisFactor = 7;
            int xGetal = 1;

            do
            {
                int product = xGetal * basisFactor;
                Console.WriteLine($"Het product van {xGetal} maal {basisFactor} is: {product}");
                xGetal = xGetal +1;

                
            }
            while (xGetal <= 10);
        }
    }
}
