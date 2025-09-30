namespace D09_aantalkarakters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de som van het aantal karakters van een reeks woorden kan bepalen.

            string[] woorden;

            woorden = new string[] { "dit", "zijn", "een", "aantal", "woorden" };


            
            

            int[] waardes;
            waardes = new int[woorden.Length];

           int i = 0;

            foreach (string woord in woorden)
            {
                waardes[i] = woord.Length;
                i++;
                
            }

            for (int index  = 1; index < waardes.Length; index++)
            {
                waardes[index] += waardes[index - 1];
            }

            Console.WriteLine(string.Join(',', waardes));
        }
    }
}
