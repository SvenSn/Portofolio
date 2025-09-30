namespace D08_fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new int[10];

            fibonacci[0] = 1;
            fibonacci[1] = 1;

            

            for (int i = 2;i < fibonacci.Length; i++)
            {

                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];

            }

            foreach (int getal in fibonacci)
            {
                Console.Write(getal + " ");
            }
        }
    }
}
