namespace D06_rechthoekigedriehoekrechts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool checkInvoer;

            int hoogte = 0;

            do
            {
                Console.WriteLine("Geef een hoogte in.");
                checkInvoer = int.TryParse(Console.ReadLine(), out hoogte); 

            } while (!checkInvoer || hoogte < 1);

            for ( int aantal = 1; aantal <= hoogte; aantal++ )
            {
                for ( int i = 0; i< hoogte - aantal; i++ )
                {
                    Console.Write(" ");
                }

                for ( int i = 0;i < aantal; i++ )
                {
                    Console.Write("*");
                }
                Console.WriteLine();

            }




        }
    }
}
