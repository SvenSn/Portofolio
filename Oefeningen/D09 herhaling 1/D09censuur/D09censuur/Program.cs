namespace D09censuur
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
                    
                    string sterretjes = new string('*', lengte);
                    tekst = tekst.Insert(index, sterretjes);

                   
                    index = tekstKlein.IndexOf(scheldwoord, index + lengte);
                }

            }

            
            Console.WriteLine(tekst);

        }
    }
}
