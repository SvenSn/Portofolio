namespace D05driehoek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Rechthoekzijde?: ");
            int zijde = int.Parse(Console.ReadLine());

            int breedtezijde = zijde;

            int hoogteller = 0;

            do
            {
                int breedteteller = 0;
                do
                {
                    Console.Write("*");
                    breedteteller++;
                } while (breedteteller < breedtezijde);

                Console.WriteLine();
                hoogteller++;
                breedtezijde--;
            } while (hoogteller < zijde);
        }
    }
}
