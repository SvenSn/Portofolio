namespace D09_morse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker telkens om de Morse code voor een letter vraagt en zo gaandeweg een tekstbericht opbouwt

            string[] morse = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            string uitvoer = "";
            bool morseGevonden = false;






            for (int i = 0; i < morse.Length; i++)
            {
                Console.WriteLine("Morse code voor de volgende letter (. voor kort, - voor long)");
                string invoer = Console.ReadLine();


                if (invoer == morse[i])
                {
                    uitvoer += letters[i];
                    Console.WriteLine($"tekst tot nu toe is : {uitvoer}");
                }
                else
                {
                    Console.WriteLine("Ongeldige morse code");
                }


            }





        }


    }
}
