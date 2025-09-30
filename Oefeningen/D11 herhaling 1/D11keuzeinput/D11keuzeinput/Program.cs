
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
            bool isOK = false;
            int index = 0;
            do
            {
                Console.Write("Geef uw keuze (Rood|Groen|Blauw) :");
                string keuze = Console.ReadLine();
                

                for (int i = 0; i < keuzes.Length; i++)
                {
                    if (keuzes[i] == keuze)
                    {
                        index = i;
                        isOK = true;
                        break;
                    }
                }
            } while (!isOK);
            
            return index;
        }
    }
}
