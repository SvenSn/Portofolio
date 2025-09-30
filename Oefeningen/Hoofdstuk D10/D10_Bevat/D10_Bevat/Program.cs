

namespace D10_Bevat
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



            bool isBoerderijDier = Bevat(boerderijDieren, dier);


            if (isBoerderijDier)
            {
                Console.WriteLine($"{dier.ToLower().Trim()} is een boerderijdier.");
            }
            else
            {
                Console.WriteLine($"{dier.ToLower().Trim()} is geen boerderijdier.");
            }


        }

        private static bool Bevat(string[] boerderijDieren, string? dier)
        {
            bool isBoerderijDier = false;   

            foreach (string dieren in boerderijDieren)
            {
                if (dier.ToLower() == dieren.ToLower())
                {
                    isBoerderijDier = true;
                    break;
                }
            }
            return isBoerderijDier;
        }
    }
}
