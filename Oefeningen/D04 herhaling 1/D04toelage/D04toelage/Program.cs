namespace D04toelage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef het jaarinkomen in: ");
            double jaarinkomen = double.Parse(Console.ReadLine());

            Console.Write("Geef het aantal kinderen in.: ");
            int aantalKinderen = int.Parse(Console.ReadLine());

            double toelage = 3 / 100.0;
            double toelageTotaal;

            if (aantalKinderen > 3 || jaarinkomen < 20000)
            {
                toelageTotaal = (jaarinkomen * toelage);    
            }
            else
            {
                toelageTotaal = 0;
            }

            Console.WriteLine($"Uw toelage bedraagt {toelageTotaal}");
        }
    }
}
