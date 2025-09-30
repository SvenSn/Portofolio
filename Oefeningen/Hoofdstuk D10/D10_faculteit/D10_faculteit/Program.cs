
namespace D10_faculteit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een getal vraagt en de faculteit van dat getal afbeeldt.

            Console.WriteLine("Geef een getal in. ");
            int getal = int.Parse(Console.ReadLine());



            int getalFac = GetFaculteit(getal);

            Console.WriteLine($"{getal}! is {getalFac}");

        }

        private static int GetFaculteit(int getal)
        {
            int resultaat = 1;

            for (int i = 2; i <= getal; i++)
            {
                resultaat =  resultaat * i;
            }
            return resultaat;
        }
    }
}
