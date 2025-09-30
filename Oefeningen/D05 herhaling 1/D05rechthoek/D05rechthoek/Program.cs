using System;

namespace D05rechthoek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoogte?: ");
            int hoogte = int.Parse(Console.ReadLine());

            Console.Write("Breedte?: ");
            int breedte = int.Parse(Console.ReadLine());

            int hoogteTeller = 0;

            do
            {
                int breedteTeller = 0;
                do
                {
                    Console.Write("*");
                    breedteTeller++;

                } while (breedteTeller < breedte);
                Console.WriteLine();
                hoogteTeller++;

            } while (hoogteTeller < hoogte);
        }
    }
}
