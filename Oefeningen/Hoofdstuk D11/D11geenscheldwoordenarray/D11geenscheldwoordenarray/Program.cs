
namespace D11geenscheldwoordenarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Herschrijf de oplossing van D09geenscheldwoorden zodat het programma een method IsAanvaardbaar gebruikt.
            //Deze method heeft 1 parameter (de tekst) en retourneert een true of false waarde al naargelang of de tekst aanvaardbaar is of niet.


            string[] scheldWoorden = { "doos", "dwaas", "geit", "boef", "klapluis", "klojo", "gluiper", "heks", "broodaap", "choco" };

            Console.WriteLine("Geef een tekst in.");
            string tekst = Console.ReadLine();
            string tekstLower = tekst.ToLower();

            isAanvaardBaarMethod(tekstLower);

            bool isAanvaardbaar = isAanvaardBaarMethod(tekstLower);

            if (isAanvaardbaar)
            {
                Console.WriteLine("Tekst is aanvaardbaar.");
            }
            else
            {
                Console.WriteLine("Tekst is onaarvaardbaar.");
            }

            static bool isAanvaardBaarMethod(string tekst)
            {

                string[] scheldWoorden = { "doos", "dwaas", "geit", "boef", "klapluis", "klojo", "gluiper", "heks", "broodaap", "choco" };

                

                foreach (string schelden in scheldWoorden)
                {
                    if (tekst.Contains(schelden))
                    {
                        return false;
                        break;
                    }
                   
                }
                return true;
            }
        }
    }
}
