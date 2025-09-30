namespace D09morse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            string bericht = "";

            bool isGevonden = false;

            while (true)
            {
                Console.WriteLine("Geef morse code in. (. voor kort, - voor lang)");
                string input = Console.ReadLine();



                for (int i = 0; i < morse.Length; i++)
                {
                    if (input == morse[i])
                    {
                        isGevonden = true;  
                      bericht += letters[i].ToString();
                        break;
                        
                    }   
                }


                if (isGevonden)
                {
                    Console.WriteLine("opgebouwde bericht: " + bericht);
                }
                else if (!isGevonden)
                {
                    Console.WriteLine("Ongeldige morsecode! ");
                }

                
            }
        }
    }
}
