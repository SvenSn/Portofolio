

namespace D11keuzeinput
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] keuzes = { "Rood", "Groen", "Blauw" };
            int index = GetKeuze(keuzes);
            string kleur = keuzes[index];
            Console.WriteLine($"U koos {kleur}");
        }

        private static int GetKeuze(string[] keuzes)
        {
            int resultaat;
            do
            {
                Console.WriteLine("Geef uw keuze. " + string.Join("|", keuzes));
                string invoer = Console.ReadLine();

               

                resultaat = IndexHoofdLetter(keuzes, invoer);
            } while (resultaat == -1);

            return resultaat;
        }

        private static int IndexHoofdLetter(string[] keuzes, string? invoer)
        {
            string textLower = invoer.ToLower();

            for (int i = 0; i < keuzes.Length; i++)
            {
                string invoerLower = keuzes[i].ToLower();
                if (invoerLower.Contains(textLower))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
