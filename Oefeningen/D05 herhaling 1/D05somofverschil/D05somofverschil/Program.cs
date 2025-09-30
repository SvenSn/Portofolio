namespace D05somofverschil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resultaat = int.Parse(Console.ReadLine());  
            string symbool = Console.ReadLine();    

            while (symbool != "=")
            {
                int getal = int.Parse(Console.ReadLine());

                if (symbool == "+")
                {
                    resultaat = resultaat + getal;
                }else if (symbool == "-")
                {
                    resultaat = resultaat - getal;
                }

                symbool = Console.ReadLine();
            }

            Console.WriteLine(resultaat);
        }
    }
}
