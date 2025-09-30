namespace D08_dagnummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker om een dagnummer vraagt van 1 t.e.m. 7 en vervolgens toont welke weekdag daarmee overeenkomt (maandag is dag 1).

            string[] dagen = new string[7] { "maandag", "dinsdag", "woensdag", "donderdag", "vrijdag", "zaterdag", "zondag" };



            Console.Write("Geef een dagnummer in :");
            string getalText = Console.ReadLine();

            int dag = 0;

            bool isDag = int.TryParse(getalText, out dag);

            if (isDag && dag >=1 && dag <= 7)
            {
                string[] dagText = {"Maandag","Dinsdag","Woensdag","Donderdag","Vrijdag","Zaterdag","Zondag"};

                int indexDag = dag - 1;

                string dagNaam = dagText[indexDag];

                Console.WriteLine($"{dagNaam} is dag nummer {dag}");



            }


           

        }    
    }
}
