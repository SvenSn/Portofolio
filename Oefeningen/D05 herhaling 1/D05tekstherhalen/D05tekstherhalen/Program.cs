namespace D05tekstherhalen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een tekst in: ");
            string tekst = Console.ReadLine();

            Console.Write("Geef een aantal in: ");
            int aantal = int.Parse(Console.ReadLine());

            int teller = 1;

            while (teller <= aantal )
            {
                if (teller == aantal)
                {
                    Console.Write(tekst.ToUpper());
                }
                else
                {
                    {
                        Console.Write(tekst);
                    }
                }
                teller++;
            }
        }
    }
}
