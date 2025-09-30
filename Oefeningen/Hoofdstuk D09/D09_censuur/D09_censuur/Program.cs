namespace D09_censuur
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een tekst vraagt en vervolgens diezelfde tekst gecensureerd weergeeft. Elk scheldwoord
            //(uit een voorgedefiniëerde lijst) wordt vervangen door een even lange rij sterretjes, bv. druiloor wordt vervangen door ********.
            //De zoektocht naar scheldwoorden is hoofdletterongevoelig.

            string[] scheldWoorden = { "doos", "dwaas", "geit", "boef", "klapluis", "klojo", "gluiper", "heks", "broodaap", "choco" };

            Console.Write("Geef een tekst : ");
            string tekst = Console.ReadLine();

            string tekstLower = tekst.ToLower();

            foreach (string scheldwoord in scheldWoorden)
            {
                
                int check =  tekstLower.IndexOf(scheldwoord);
                
                while (check != -1)
                {
                    int lengtewoord = scheldwoord.Length;


                    tekst = tekst.Remove(check , lengtewoord);
                    
                    string vervangen = new string('*', lengtewoord);
                    tekst = tekst.Insert(check , vervangen);


                    check = tekstLower.IndexOf(scheldwoord, check + lengtewoord);
                }

            }

            Console.WriteLine(tekst);
            
        }
    }
}
