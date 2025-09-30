namespace D08_aansprekingen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] aansprekingen = { "Jan", "Piet", "Pol" };

            for (int index = 0; index < aansprekingen.Length; index++)
            {

                aansprekingen[index] = "Dag " + aansprekingen[index];
            }

            foreach (string aanspreking in aansprekingen)
            {
                Console.WriteLine(aanspreking);
            }

           
        }
    }
}
