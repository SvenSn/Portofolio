using D15afstandtussenpunten.Domein;

namespace D15afstandtussenpunten.CUI
{
    public class AfstandApp
    {
        public void Run()
        {


            Afstand a1 = new Afstand(7, 9);
            Afstand a2 = new Afstand(3,5);

            double afstandPunten = Afstand.GetAfstandTussen(a1, a2);

            Console.WriteLine($"De afstand tussen deze twee punten is {afstandPunten}");

        }
    }
}
