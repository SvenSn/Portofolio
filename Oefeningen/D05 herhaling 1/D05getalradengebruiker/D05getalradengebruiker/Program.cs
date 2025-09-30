namespace D05getalradengebruiker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();    
            int nummer = r.Next(1,100);

            int gok;

            Console.WriteLine("De computer denkt aan een getal van 1 tem 100, kun je raden welk?");

            do
            {
                Console.Write("Wat gok je? ");
                gok = int.Parse(Console.ReadLine());    

                if (gok > nummer)
                {
                    Console.WriteLine("Lager!");
                }
                else if (gok < nummer)
                {
                    Console.WriteLine("Hoger!");
                }
                else
                {
                    Console.WriteLine("Disco!");
                    break;
                }
                
            }while (gok != nummer);
        }
    }
}
