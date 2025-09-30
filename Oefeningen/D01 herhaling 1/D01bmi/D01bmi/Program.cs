using System.Reflection.Metadata.Ecma335;

namespace D01bmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengteInCm = 182;
            int gewichtInKg = 72;
            double lengteInM = lengteInCm / 100.0;

            double bmi = gewichtInKg / (lengteInM * lengteInM);

            Console.WriteLine(bmi);
        }
    }
}
