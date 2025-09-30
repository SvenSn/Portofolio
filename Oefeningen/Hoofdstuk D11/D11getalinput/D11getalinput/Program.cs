
using System.Threading.Tasks.Sources;

namespace D11getalinput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method GetGetal met 2 parameters min en max (gehele getallen) die een int waarde oplevert.


            int getal = GetGetal(1, 100);
            Console.WriteLine($"U koos voor {getal}");
        }

        private static int GetGetal(int min, int max)
        {
            int getal;
            bool correcteInput;

            do
            {

                Console.WriteLine($"Geef een getal van {min} tot en met {max}.");
                string invoer = Console.ReadLine();

                correcteInput = int.TryParse( invoer, out getal);


            }while (!correcteInput || getal < min || getal > max);

            return getal;
        }
    }
}
