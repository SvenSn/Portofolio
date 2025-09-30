using D18reversedstringcomparer.Domein;

namespace D18reversedstringcomparer.CUI
{
    public class StringApp
    {
        public void Run()
        {
            List<string> woorden = new List<string> { "kAT", "Aap", "kat", "HOND", "varken", "zebra", "hondshaai", "aap", "grinch", "varkenshaasje", "hond", "rothond" };

            
            woorden.Sort();
            Console.WriteLine(String.Join(", ", woorden));

            
            woorden.Sort(new ReversedStringComparer());
            Console.WriteLine(String.Join(", ", woorden));
        }
    }
}
