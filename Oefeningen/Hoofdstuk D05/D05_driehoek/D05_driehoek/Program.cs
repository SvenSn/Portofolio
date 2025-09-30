namespace D05_driehoek
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Maak een programma dat op basis van een bepaalde ingevoerde lengte van een rechthoekszijde 
             * een corresponderende gelijkbenige driehoek, bestaande uit sterren gaat afdrukken. */

            Console.Write("Rechthoekzijde?: ");
            int zijde = int.Parse(Console.ReadLine());
            int breedte = zijde;

            int hoogte = 0;
            do
            {
                int tellerBreed = 0;
                do
                {
                    Console.Write("*");
                    tellerBreed = tellerBreed + 1;
                }
                while (tellerBreed < breedte);
                Console.WriteLine();

                 hoogte = hoogte + 1;
                breedte = breedte - 1;
            }
            while( hoogte < zijde );

        }
    }
}
