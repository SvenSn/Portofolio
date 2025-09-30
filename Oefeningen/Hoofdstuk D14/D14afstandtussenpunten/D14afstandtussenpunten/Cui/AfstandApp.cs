using D14afstandtussenpunten.Domein;

namespace D14afstandtussenpunten.Cui
{
    public class AfstandApp
    {
        public void Run()
        {
            Punt p1 = new Punt(4,6);
            Punt p2 = new Punt(7,2);

            Console.WriteLine($"De afstand tussen deze 2 punten zijn {Punt.AfstandTussen(p1, p2)}");
        }
    }
}
