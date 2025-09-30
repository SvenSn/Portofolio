namespace D02quotient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Deeltal?");
            string deeltalText = Console.ReadLine();
            double deeltal = double.Parse(deeltalText);

            Console.WriteLine("Deler?");
            string delerText = Console.ReadLine();
            double deler = double.Parse(delerText);
            double quotient = deeltal / deler;


            if (deler == 0)
            {
                Console.WriteLine("Ongeldige deler, delen door 0 is niet toegelaten. ");
            }
            else
            {
                Console.WriteLine($"quotient is {quotient}");
            }


            

           
        }
    }
}
