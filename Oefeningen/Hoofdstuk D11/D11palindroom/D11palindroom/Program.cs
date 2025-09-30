
namespace D11palindroom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een woord vraagt en toont of dit woord een palindroom is.

            //Een palindroom is een tekst die identiek is als je hem achterstevoren zet. Om het wat interessanter te maken :
            //een lege tekst is geen palindroom en elke tekst van lengte 1 is wel een palindroom.


            Console.Write("Geef een woord in. ");
            string woord = Console.ReadLine();

            Console.WriteLine(isPalindroom(woord));

        }

        private static bool isPalindroom(string? woord)
        {
            string check = "";

            foreach (char c in woord)
            {
                check = c + check;
            }

            if (check == woord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
