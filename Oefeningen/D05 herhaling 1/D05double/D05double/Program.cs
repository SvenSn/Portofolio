namespace D05double
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Voer een double in: ");
            double getal;

            bool isDouble = double.TryParse(Console.ReadLine(), out getal); 

            while (isDouble)
            {
                Console.WriteLine("Dank je voor het (double) getal");
                Console.Write("Gelieve nog een (double) getal in te voeren?: ");
                isDouble = double.TryParse(Console.ReadLine(),out getal);
            }

            Console.WriteLine("Einde (wegens geen double getal).");
        }
    }
}
