namespace D08_toongetallen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 3, 1, -1, -3};



            for (int i = 0; i < a.Length; i++) 
            {
                Console.WriteLine(string.Join(", ", a));
            }
        }
    }
}
