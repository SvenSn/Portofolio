namespace D08positieszoekenmooier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 3, 1, -1, -3, 3, 9, -4 };

            Console.Write("Geef een waarde in: ");
            int waarde = int.Parse(Console.ReadLine());

            string tekst = "";

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == waarde)
                {
                    tekst += i + " ";
                }
            }


            if(tekst != "")
            {
                Console.WriteLine($"De waarde {waarde} is gevonden op positie(s) {tekst}");
            }
            else
            {
                Console.WriteLine("Waarde niet gevonden.");
            }
        }
    }
}
