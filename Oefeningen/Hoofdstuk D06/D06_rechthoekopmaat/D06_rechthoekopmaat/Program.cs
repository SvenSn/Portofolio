namespace D06_rechthoekopmaat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om 2 positieve getallen vraagt (breedte en hoogte)
            //en vervolgens een rechthoek toont met de gevraagde afmetingen.
            bool checkInvoer;

            int breedte = 0;
            do
            {
                Console.WriteLine("Geef de breedte in.");
                checkInvoer = int.TryParse(Console.ReadLine(), out breedte);
            }
            while (!checkInvoer || breedte < 1);

            int hoogte = 0;
            do
            {
                Console.WriteLine("Geef de hoogte in");
                checkInvoer = int.TryParse (Console.ReadLine(), out hoogte);
            } while (!checkInvoer || hoogte < 1);

            string opbouw = "";

            for (int i = 0;i<breedte;i++)
            {
                opbouw += "*";
            }

            for (int i = 0; i<hoogte;i++)
            {
                Console.WriteLine (opbouw);
            }
        }
    }
}
