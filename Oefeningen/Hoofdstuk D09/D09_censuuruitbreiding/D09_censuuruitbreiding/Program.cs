namespace D09_censuuruitbreiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] scheldWoorden = { "doos", "dwaas", "geit", "boef", "klapluis", "klojo", "gluiper", "heks", "broodaap", "choco" };

            Console.Write("Geef een tekst : ");
            string tekst = Console.ReadLine();

            string tekstLower = tekst.ToLower();

            foreach (string scheldwoord in scheldWoorden)
            {

                int check = tekstLower.IndexOf(scheldwoord);

                while (check != -1)
                {
                    int lengtewoord = scheldwoord.Length-1;
                    


                    tekst = tekst.Remove(check, lengtewoord);

                    string vervangen = scheldwoord[0] + new string('*', lengtewoord - 1);
                    tekst = tekst.Insert(check, vervangen);


                    check = tekstLower.IndexOf(scheldwoord, check + lengtewoord);
                }

            }

            Console.WriteLine(tekst);

        }
    }
}
