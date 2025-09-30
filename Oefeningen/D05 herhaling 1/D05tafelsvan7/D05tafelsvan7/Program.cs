namespace D05tafelsvan7
{
    internal class Program
    {
        static void Main(string[] args)
        {
           const int factor = 7;
            int teller = 1;
            int resultaat;
            do
            {
                resultaat = factor * teller;
                Console.WriteLine($"{teller} x {factor} = {resultaat}");
                teller++;

                
            } while (resultaat < 70);
        }
    }
}
