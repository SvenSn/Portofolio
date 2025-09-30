namespace D08dagnummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een dagnummer vraagt van 1 t.e.m. 7 en vervolgens toont welke weekdag daarmee overeenkomt (maandag is dag 1).


            Console.WriteLine("Geef een dagnummer in. ");
            string dagnummerText = Console.ReadLine();

            bool isOK = int.TryParse(dagnummerText,out int dagnummer);

            if (isOK && dagnummer > 0 && dagnummer <= 7 )
            {
                string[] dagNamen = { "maandag", "dinsdag", "woensdag", "donderdag",
                          "vrijdag", "zaterdag", "zondag" };

                int i = dagnummer - 1;
                string dagNaam = dagNamen[i];

                Console.WriteLine($"dag nummer {dagnummer} is {dagNaam}");
            }
        }
    }
}
