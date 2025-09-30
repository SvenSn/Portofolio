namespace D06_sommeer1tem10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de kwadraten van de getallen van 1 t.e.m. 10 sommeert en het resultaat toont.
              int som = 0;
            for (int i = 1; i <= 10; i++)
            {
                int kwadraat = i * i;
                som = som + kwadraat;
            }
            Console.WriteLine($" De som van het kwadraat van [1,10] is {som}");
        }
    }
}
