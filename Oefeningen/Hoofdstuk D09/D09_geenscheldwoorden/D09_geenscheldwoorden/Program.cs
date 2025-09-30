namespace D09_geenscheldwoorden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst vraagt en vervolgens toont of deze tekst al dan niet aanvaardbaar is.
            //De tekst wordt enkel aanvaard indien er geen scheldwoorden in voorkomen (op basis van een lijst). De zoektocht naar scheldwoorden is hoofdletterongevoelig.

            string[] scheldWoorden = {"doos","dwaas","geit","boef","klapluis","klojo","gluiper","heks","broodaap","choco" };

            Console.WriteLine("Geef een tekst in.");
            string tekst = Console.ReadLine();
            string tekstLower = tekst.ToLower();


            bool isAanvaardbaar = true;

            foreach (string schelden in scheldWoorden)
            {
                if (tekstLower.Contains(schelden))
                {
                    isAanvaardbaar = false;
                    break;
                }
            }

            if (isAanvaardbaar)
            {
                Console.WriteLine("Tekst is aanvaardbaar.");
            }
            else
            {
                Console.WriteLine("Tekst is onaarvaardbaar.");
            }


        }
    }
}
