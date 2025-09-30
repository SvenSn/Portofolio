
namespace D11getalinput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int getal = GetGetal(1, 100);
            Console.WriteLine($"U koos voor {getal}");
        }

        private static int GetGetal(int min, int max)
        {
            bool invoerOK;
            int getal = 0;

            do
            {
                Console.Write("Geef een getal van 1 t.e.m. 100: ");
                string invoer = Console.ReadLine();
                invoerOK = int.TryParse(invoer, out getal);


            }while(!invoerOK || getal < 1 || getal > 100);

            return getal;
        }
    }
}
