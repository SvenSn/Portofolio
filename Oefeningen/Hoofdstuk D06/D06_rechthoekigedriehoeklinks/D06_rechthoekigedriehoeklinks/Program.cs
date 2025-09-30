namespace D06_rechthoekigedriehoeklinks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Vraag de gebruiker om een geheel getal en toon een rechthoekige driehoek
            //(met rechte hoek aan de linkerkant) van de gewenste afmeting.
            bool checkInvoer;

            int hoogte = 0;
            do
            {
                Console.WriteLine("Geef de hoogte in.");
                checkInvoer = int.TryParse(Console.ReadLine(), out hoogte); 
            } while (!checkInvoer || hoogte < 1);

            for (int h = 1; h <= hoogte; h++)
            {
                for (int i = 0; i < h; i++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }




        }
    }
}
