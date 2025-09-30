namespace D04geslaagd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef uw eerste score in: ");
            int getal1 = int.Parse(Console.ReadLine());

            Console.Write("Geef uw tweede score in: ");
            int getal2 = int.Parse(Console.ReadLine());


            Console.Write("Geef uw derde score in: ");
            int getal3 = int.Parse(Console.ReadLine());

            int totaal = getal1 + getal2 + getal3;
            string geslaagd = "";

            if (getal1 >= 5 && getal2 >= 5 && getal3 >= 5 || totaal >= 18 && getal1 >= 4 && getal2 >= 4 && getal3 >=4  )
            {
                geslaagd = "Geslaagd";
            }
            else
            {
                geslaagd = "Niet geslaagd";
            }

            Console.WriteLine($"U bent {geslaagd}");
        }
    }
}
