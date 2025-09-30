using System.Runtime.InteropServices;

namespace D09dagnummernaarmaand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] aantalDagen = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] maandNamen = { "Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December" };


            Console.Write("Geef een dagnummer in: ");
            int dagnummer = int.Parse(Console.ReadLine());

            string maand = "";
            int laatsteDagMaand = 0;

            for (int i = 0; i < aantalDagen.Length; i++)
            {
                laatsteDagMaand += aantalDagen[i];

                if (dagnummer <= laatsteDagMaand)
                {
                    maand = maandNamen[i];
                    break;
                }
            }

            Console.WriteLine($"Dit is de maand {maand}");
        }
    }
}
