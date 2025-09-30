using D18stringznaara.Domein;

namespace D18stringznaara.CUI
{
    public class StringApp
    {
        public void Run()
        {
            List<string> woorden = new List<string> { "kAT", "Aap", "kat", "HOND", "varken", "zebra", "hondshaai", "aap", "grinch", "varkenshaasje", "hond" };


            woorden.Sort();
            Console.WriteLine(String.Join(", ", woorden));


            woorden.Sort(new StringComparerOmgekeerd());
            Console.WriteLine(String.Join(", ",woorden));


        }
    }
}
