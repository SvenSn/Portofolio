namespace D05som
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int som = 0;
            int getal;
            do
            {
                Console.Write("Geef een getal in: ");
                getal = int.Parse(Console.ReadLine());

                if(getal > 0)
                {
                    som += getal;
                }

            } while (getal != -1);

            Console.WriteLine(som);
        }
    }
}
