namespace D05vierkant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zijde?: ");
            int zijde = int.Parse(Console.ReadLine());

            int hoogteTeller = 0;

            do
            {
                int breedteTeller = 0;
                do
                {
                    Console.Write("*");
                    breedteTeller++;
                }while (breedteTeller < zijde);


                Console.WriteLine();
                hoogteTeller++;

            }while (hoogteTeller < zijde);

        }
    }
}
