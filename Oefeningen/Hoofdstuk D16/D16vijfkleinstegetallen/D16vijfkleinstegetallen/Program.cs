namespace D16vijfkleinstegetallen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om 10 getallen vraagt en vervolgens de 5 kleinste ingevoerde getallen weergeeft.

            const int aantal = 10;

            const int kleinsteGetallen = 5;


            List<int> getallen = new List<int>();

            while (getallen.Count < aantal)
            {
                Console.Write("Geef een getal : ");
                string invoer = Console.ReadLine();


                //bool maken die weergeeft of de parse is gelukt en dus inderdaad een int is ingevoerd
                bool invoerOK = int.TryParse(invoer, out int getal);



                if (invoerOK )
                {
                    getallen.Add(getal);
                }
                else
                {
                    Console.WriteLine("ongeldige invoer ");
                }
            }
            // getallen sorteren dus tijd uitgespaart met deze functie , sorteert van klein naar groot
            getallen.Sort();


            // eerste 5 elementen in de list writing door de soorteren zijn did inderdaad de 5 kleinste getallen
            Console.WriteLine("De 5 kleinste getallen zijn ");
            for (int i = 0; i < kleinsteGetallen; i++)
            {
                Console.Write(getallen[i] + " ");
                
            }

           
        }
    }
}
