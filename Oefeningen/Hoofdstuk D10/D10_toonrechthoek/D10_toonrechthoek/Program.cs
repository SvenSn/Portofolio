


namespace D10_toonrechthoek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method ToonRechthoek met 2 parameters (breedte en hoogte) die een rechthoek van sterretjes op de console zet.


            Console.Write("Geef de hoogte in. ");
            int hoogte = int.Parse(Console.ReadLine());

            Console.Write("Geef de breedte in. ");
            int breedte = int.Parse(Console.ReadLine());

            ToonRechtHoek(breedte, hoogte);
        }

        private static void ToonRechtHoek(int breedte, int hoogte)
        {
            for (int i = 0; i < hoogte; i++)
            {
                for (int j = 0; j < breedte; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();    
            }
           
        }
    }
}
