namespace D09aantalkarakters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] woorden;

            woorden = new string[] { "dit", "zijn", "een", "aantal", "woorden" };                  // 3,7,10,16,23
                                                                                                   //woorden = new string[] { "dit", "zijn", "dan", "weer", "wat", "andere", "woorden" }; // 3,7,10,14,17,23,30
            int[] aantalKarakters = new int[woorden.Length];

            int som = 0;
            
            int index = 0;


            foreach (string woord in woorden)
            {
                int teller = 0;
                foreach (char c in woord)
                {
                    teller++;
                    
                }
                som += teller;
                aantalKarakters[index] = som;
                index++;
            }




            Console.WriteLine(string.Join(',', aantalKarakters));
        }
    }
}
