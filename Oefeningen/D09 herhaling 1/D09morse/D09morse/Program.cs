using System.ComponentModel.Design;

namespace D09morse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            while (true)
            {
                Console.Write("Morse code voor de volgende letter (. voor kort, - voor lang) ?: ");
                string invoer = Console.ReadLine();

                string bericht = "";
                bool isGevonden = true;
                for (int i = 0; i < morse.Length; i++)
                {
                    if (invoer == morse[i])
                    {
                        isGevonden = true ;
                        bericht += letters[i];
                        break;
                    }
                    else
                    {
                        isGevonden = false ;
                    }
                }
                if (isGevonden)
                {
                    Console.WriteLine($"Opgebouwde tekst tot nu toe : {bericht} ");
                }
                else 
                {
                    Console.WriteLine("Ongeldige morse code!");
                }
            }
        }
    }
}
