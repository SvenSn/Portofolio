namespace D05_som
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker meermaals om een getal vraagt (totdat de gebruiker een -1 ingeeft).
            //Voor de eenvoud gaan we er hier van uit dat de gebruiker netjes getallen invoert, je hoeft hier niet op te controleren.
            int getal = 0;
            int som = 0;

            do
            {
                Console.WriteLine("Geef een getal in.");
                getal = Int32.Parse(Console.ReadLine());
                som += getal;
            }
            while (getal != -1);


            som -= getal;

            Console.WriteLine($"De som is {som}");
        }
        
    }
}
