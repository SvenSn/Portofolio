namespace D05aantal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de gebruiker meermaals om een getal vraagt,
            //totdat de gebruiker twee keer na elkaar hetzelfde getal ingeeft.
            //Voor de eenvoud gaan we er hier van uit dat de gebruiker netjes getallen invoert,
            //je hoeft hier niet op te controleren.

            int getal = 0;  
            int vorigGetal = 0;
            bool volgend = true;
            int teller = 0; 

            do
            {

                Console.Write("Geef een getal in: ");
                getal = int.Parse(Console.ReadLine());
                teller++;

                if (teller >= 2 && vorigGetal == getal)
                {
                    volgend = false;
                }else
                {
                    vorigGetal = getal;
                }


            } while (volgend);

            teller --;

            Console.WriteLine($"Aantal ingevoerde getallen: {teller}");
        }
    }
}
