namespace D06rechthoekigedriehoeklinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool invoerOK;
            int hoogte = 0;


            do
            {
                Console.Write("Geef de hoogte in: ");
                invoerOK = int.TryParse(Console.ReadLine(), out hoogte);
            } while (!invoerOK || hoogte < 1);


              for (int i = 1; i <= hoogte; i++)
            {
                for (int j = 0; j < i ; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

        }
    }
}
