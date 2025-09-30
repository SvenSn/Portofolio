namespace D09_zoekdier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //schrijf de rest van de code zodat het de gebruiker om een dier vraagt.
            //Het programma meldt vervolgens of het wel of niet om een boerderijdier gaat. Dit programma is hoofdletterONgevoelig.


            string[] boerderijDieren = { "kip", "koe", "paard", "geit", "schaap" };


            Console.WriteLine("Geef een dier in.");
            string dier = Console.ReadLine();


            bool isBoerderijDier = false;

            for (int i = 0; i < boerderijDieren.Length; i++)
            {
                if (boerderijDieren[i] == dier.ToLower().Trim())
                {
                    isBoerderijDier = true;
                    break;
                }  
            }

            if (isBoerderijDier )
            {
                Console.WriteLine($"{dier.ToLower().Trim()} is een boerderijdier.");
            }
            else
            {
                Console.WriteLine($"{dier.ToLower().Trim()} is geen boerderijdier.");
            }

        }
    }
}
