using D14counterProject.Domein;

namespace D14counterProject.Cui
{
    public class CounterApp
    {
        public void Run()
        {
            Counter c1 = new Counter();

            Counter c2 = new Counter();
            c2.Value = 100;

            Counter c3 = new Counter();
            c3.Value = 1000;
            c3.Step = 10;

            for (int i = 0; i < 10; i++)
            {
                c1.Advance();
                c2.Advance();
                c3.Advance();
            }

            Console.WriteLine(c1.Value);  // toont 10
            Console.WriteLine(c2.Value);  // toont 110
            Console.WriteLine(c3.Value);  // toont 1100
        }

    }
}
