using D14afstandtussenpunten.Domein;

namespace D14afstandtussenpunten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Punt p1 = new Punt();
            p1.PuntX = 4;
            p1.PuntY = 6;

            Punt p2 = new Punt();
            p2.PuntX =  7;
            p2.PuntY = 2;

            double afstand = Punt.AfstandTussen(p1, p2);

            Console.WriteLine($"De afstand is {afstand}");
        }
    }
}
