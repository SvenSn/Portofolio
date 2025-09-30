
namespace D11geenscheldwoordenarray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst : ");
            string tekst = Console.ReadLine();

            bool isOk = IsAanvaardbaar(tekst);

            if (isOk)
            {
                Console.WriteLine("Tekst is aanvaardbaar");
            }
            else
            {
                Console.WriteLine("Tekst is niet aanvaardbaar");
            }
        }

        private static bool IsAanvaardbaar(string tekst)
        {
            string[] scheldWoorden = { "doos", "dwaas", "geit", "boef", "klapluis", "klojo", "gluiper", "heks", "broodaap", "choco" };


            string tekstKlein = tekst.ToLower();    
            bool isOk = true;
            foreach (string scheldwoord in scheldWoorden)
            {
                if (tekstKlein.Contains(scheldwoord))
                {
                    isOk = false;
                    break;
                }
            }
            return isOk;
        }
    }
}
