namespace D05_twintigtotenmettien
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Breng aan de hand van een do while statement alle even getallen van 20 tot en met 10 op de console.
            int getal = 20;

            do
            {
                Console.WriteLine(getal);
                getal = getal - 2;
            }
            while (getal >= 10);
        }
    }
}
