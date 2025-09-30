namespace D08_positieszoekenmooier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 3, 1, -1, -3, 3, 9, -4 };


            Console.WriteLine("Geef een waarde in.");
            int waarde = Int32.Parse(Console.ReadLine());


            string tekst = "";

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == waarde)
                {
                    waarde = a[i];
                    tekst += i + " ";
                }                
            }

            if(tekst != "")
            {
                Console.WriteLine($"waarde {waarde} gevonden op positie(s) {tekst}");
            }
            else
            {
                Console.WriteLine("waarde niet gevonden");
            }
            

        }
    }
}
