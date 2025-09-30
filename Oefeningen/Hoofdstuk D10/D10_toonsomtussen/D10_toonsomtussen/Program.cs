using System.ComponentModel.DataAnnotations;

namespace D10_toonsomtussen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method ToonSomTussen met 2 parameters min en max die de som toont van alle getallen tussen min en max (grenzen inclusief).

            int min = 0;
            int max = 20;


            ToonSom(min, max);


        }

        private static void ToonSom(int min, int max)
        {

            int som = 0;

            for (int i = min; i <= max;i++)
            {
                som += i;
            }

            Console.WriteLine($"De som van de getallen {min} tot en met {max} is {som}.");

        }
    }
}
