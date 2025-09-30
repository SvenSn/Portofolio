using System.ComponentModel.Design;

namespace D07_begintmethoofdletter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om tekst vraagt en dat weergeeft of die tekst start met een hoofdletter of kleine letter.

            Console.Write("Geef een tekst: ");
            string tekst = Console.ReadLine();

            bool hoofdLetterGevonden = false;

            int eersteLetter = 0;

            foreach (char c in tekst)
            {
                eersteLetter++;
                if (eersteLetter == 1)
                {

                    if (char.IsUpper(c))
                    {

                        hoofdLetterGevonden |= true;

                    }
                }

            }

            if (hoofdLetterGevonden)
            {
                Console.WriteLine("De tekst begint met een hoofdletter");

            }
            else
            {
                Console.WriteLine("De tekst begint niet met een hoofdletter.");
            }
           
           


        }
    }
}
