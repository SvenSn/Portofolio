namespace D06simon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            string invoer;
            string code = "";

            do
            {
                int nieuwGetal = r.Next(1,5);
                code += nieuwGetal;

                Console.Clear();
                Console.WriteLine("U hebt 2 seconden om de code te onthouden.");
                Console.WriteLine(code);
                System.Threading.Thread.Sleep(2000);
                Console.Clear();


                Console.Write("Geef de code in: ");
                invoer = Console.ReadLine();    


            } while (code == invoer);

            Console.WriteLine("Helaas de code was: ");
            Console.WriteLine(code);
        }
    }
}
