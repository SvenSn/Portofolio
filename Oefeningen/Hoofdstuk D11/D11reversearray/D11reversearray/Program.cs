
namespace D11reversearray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] test0 = { }; // Duizend bommen en granaten Kuifje, een leeg array!
            string[] test1 = { "een" };
            string[] test2 = { "een", "twee" };
            string[] test3 = { "een", "twee", "drie" };
            string[] test4 = { "een", "twee", "drie", "vier" };
            string[] test5 = { "een", "twee", "drie", "vier", "vijf" };

            string[] woorden = test5;

            Console.WriteLine(string.Join(", ", woorden));
            Reverse(woorden);
            Console.WriteLine(string.Join(", ", woorden));



        }

        private static void Reverse(string[] woorden)
        {
            int laagstePositie = (woorden.Length / 2) - 1;

            for (int i = 0; i <= laagstePositie; i++)
            {
               
                int lowPos = i;
                int highPos = (woorden.Length-1) -i;

                // swappen van elementen
                string temp = woorden[lowPos];
                woorden[lowPos] = woorden[highPos];
                woorden[highPos] = temp;
            }
           
        }
    }
}
