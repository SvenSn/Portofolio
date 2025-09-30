using System.Reflection.Metadata.Ecma335;

namespace D09censuuruitbreiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] scheldWoorden = { "doos", "dwaas", "geit", "boef", "klapluis", "klojo", "gluiper", "heks", "broodaap", "choco" };

            Console.Write("Geef een tekst : ");
            string tekst = Console.ReadLine();
            string tekstKlein = tekst.ToLower();

            foreach (string scheldwoord in scheldWoorden)
            {

                int index = tekstKlein.IndexOf(scheldwoord);
                while (index != -1)
                {


                    int lengte = scheldwoord.Length;
                    

                    tekst = tekst.Remove(index, lengte);

                    char eersteLetter = scheldwoord[0];
                    char laatsteLetter = scheldwoord[lengte -1];

                    string sterretjes = new string('*',lengte-2);
                    string vervantekst = eersteLetter + sterretjes + laatsteLetter;
                    tekst = tekst.Insert(index, vervantekst);


                    index = tekstKlein.IndexOf(scheldwoord, index + lengte);
                }

            }


            Console.WriteLine(tekst);
        }
    }
}
