
namespace D10toongetallenmetmethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] getallen = { 4, 7, 9, 34, 2, 56, 34, 78 };
            ToonGetallen(getallen);
        }

        private static void ToonGetallen(int[] getallen)
        {
            Console.WriteLine(string.Join(", ", getallen));
        }
    }
}
