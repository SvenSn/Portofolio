namespace D11expand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] scores1 = { 2, 3, -5, 6 };
            int[] expanded1 = Expand(1, scores1);

            Console.WriteLine(String.Join(",", expanded1));
            // output is : 2,3,-5,6

            // voorbeeld 2 : een reeks drie keer dupliceren
            int[] scores2 = { 2, 3, -5, 6 };
            int[] expanded2 = Expand(3, scores2);

            Console.WriteLine(String.Join(",", expanded2));
            // de output is : 2,2,2,3,3,3,-5,-5,-5,6,6,6

            // voorbeeld 3 : een reeks nul keer dupliceren
            int[] scores3 = { };
            int[] expanded3 = Expand(0, scores3);

            Console.WriteLine(String.Join(",", expanded3));
            // output is : (een lege regel)
            // (de Expand oproep retourneerde immers een lege array)

            // voorbeeld 4 : een lege reeks 5 keer dupliceren
            int[] scores4 = { };
            int[] expanded4 = Expand(5, scores4);

            Console.WriteLine(String.Join(",", expanded4));

            static int[] Expand(int aantal, int[] getallen)
            {
                if (aantal == 0)
                {
                    return new int[0];
                }

                // totale lengte is de lengte van de gegeven array maal het aantal
                int length = getallen.Length * aantal;
                int[] expanded = new int[length];   
                

                for (int i = 0; i < getallen.Length; i++)
                {
                   for (int j = 0; j < aantal; j++)
                    {
                        //expanded[1*3+1] = getallen[1]
                        //expanded[2 * 3 + 2] = getallen[2]
                        //expanded[3 * 3 + 3] = getallen[3] = lengte is 12 ...ter controle voor mijzelf**

                        expanded[i * aantal + j] = getallen[i];
                    }
                }

                return expanded;
            }
        }
    }
}
