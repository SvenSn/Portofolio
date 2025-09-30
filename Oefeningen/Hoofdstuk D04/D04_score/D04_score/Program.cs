namespace D04_score
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Schrijf een programma dat de gebruiker om een score vraagt (in procent) en vervolgens de Amerikaanse lettercode weergeeft.
           /* A indien score > 82 %
              B indien score > 67 % en <= 82 %
              C indien score > 52 % en <= 67 %
              D indien score > 37 % en <= 52 %
              E indien score > 22 % en <= 37 %
              F indien score <= 22 %*/


            Console.WriteLine("Geef je score in % hier");
            int resultaat = Int32.Parse(Console.ReadLine());
            string resultaatLetter;

            if (resultaat > 82)
            {
                resultaatLetter = "A";
            }
            else if (resultaat >67 )
            {
                resultaatLetter= "B";
            }
            else if (resultaat > 52)
            {
                resultaatLetter= "C";
            }
            else if (resultaat > 37)
            {
                resultaatLetter= "D";
            }
            else if (resultaat > 22)
            {
                resultaatLetter= "E";
            }
            else
            {
                resultaatLetter = "F";
            }

            Console.WriteLine($"Jouw resultaat is een: {resultaatLetter} ");
        }
    }
}
