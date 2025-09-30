namespace D05wildebertram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maanden;
            Console.WriteLine("Geef het aantal maanden groei in: ");
            bool invoerOK = int.TryParse(Console.ReadLine(), out maanden);  

            if (invoerOK && maanden >= 1)
            {
                int fibo1 = 0;
                int fibo2 = 1;
                int fibo3;
                int teller = 1;


                do
                {
                    fibo3 = fibo1 + fibo2;
                    fibo1 = fibo2;
                    fibo2 = fibo3;

                    teller++;
                } while (teller < maanden);

                Console.Write($"Aantal knooppunten: {fibo3}");
            }
        }
    }
}
