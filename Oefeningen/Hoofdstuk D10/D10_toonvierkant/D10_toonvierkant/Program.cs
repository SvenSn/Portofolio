
namespace D10_toonvierkant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een Main method die een ToonVierkant method aanroept.

            //Deze laatste print op het console scherm een vierkant van 5 op 5 sterretjes(*).

            ToonVierkent();
        }

        private static void ToonVierkent()
        {
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();    
            }
        }
    }
}
