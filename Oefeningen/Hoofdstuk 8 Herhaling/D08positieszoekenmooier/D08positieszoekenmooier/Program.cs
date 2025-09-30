namespace D08positieszoekenmooier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 3, 1, -1, -3, 3, 9, -4 };

            Console.Write("Geef een zoekterm in. ");
            int zoekterm = int.Parse(Console.ReadLine());

            string tekst = "";
            for (int i = 0; i < a.Length; i++)
            {

                int getal = a[i];


                if (getal == zoekterm)
                {
                    tekst += i + " ";
                }
            }

            if (tekst != "")
            {
                Console.WriteLine($"zoekterm {zoekterm} gevonden op posities {tekst}");
            }
            else
            {
                Console.WriteLine("zoekterm niet gevonden");
            }
        }
    }
}
