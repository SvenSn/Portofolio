namespace D05_playlist
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Maak een programma dat berekent in hoeveel
            //verschillende volgordes je een bepaald aantal (verschillende)
            //liedjes in een playlist kan plaatsen.
            Console.WriteLine("Geef het aantal verschillende liedjes in.");
            int aantalLiedjes;
            bool invoerInOrde = int.TryParse(Console.ReadLine(), out aantalLiedjes);
            

            if (invoerInOrde && aantalLiedjes >= 1 )
            {
                int faculteit = 1;
                int factor = 2;
                while ( factor <= aantalLiedjes)
                {
                    faculteit = faculteit * factor;
                    factor = factor + 1;
                }
                string Liedjes = "";
                if (faculteit > 1)
                {
                    Console.WriteLine($"Dit aantal liedjes : {aantalLiedjes} kan op {faculteit} verschillende manieren geplaatst worden");
                }

            }
        }
    }
}
