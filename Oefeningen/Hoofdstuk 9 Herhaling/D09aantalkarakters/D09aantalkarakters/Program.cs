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
            


            for (int i = 0; i < woorden.Length; i++)
            {
                aantalKarakters[i] = woorden[i].Length;
            }


            for (int i = 1;i<aantalKarakters.Length;i++)
            {
                aantalKarakters[i] = aantalKarakters[i] + aantalKarakters[i - 1];
            }


            


            Console.WriteLine(string.Join(',', aantalKarakters));
        }
    }
}
