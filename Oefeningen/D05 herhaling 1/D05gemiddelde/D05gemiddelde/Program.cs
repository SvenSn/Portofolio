namespace D05gemiddelde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int getal;
            int som = 0;
            int gemiddelde;
            int teller = 0;

            do
            {

                Console.Write("Geef een getal in: ");
                getal = int.Parse(Console.ReadLine());  

                if (getal > 0)
                {
                    som += getal;
                    teller++;
                }
                gemiddelde = som / teller;

            } while (getal != -1);


            Console.WriteLine($"Het gemiddelde is {gemiddelde}");
        }
    }
}
