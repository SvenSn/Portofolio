namespace D06rechthoekopmaat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool invoerOK;

            int breedte = 0;
            int hoogte = 0; 

            do
            {
                Console.Write("Geef de breedte in: ");
                invoerOK = int.TryParse(Console.ReadLine(), out breedte);
            } while (!invoerOK || breedte < 1);


            do
            {
                Console.Write("Geef de hoogte in: ");
                invoerOK = int.TryParse(Console.ReadLine(), out hoogte);
            } while (!invoerOK || hoogte < 1);


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
