
namespace D11kader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToonInKader("Hallo");
        }

        private static void ToonInKader(string v)
        {
            int breedte = v.Length + 4;

            Console.WriteLine(new string('*', breedte));
            Console.WriteLine($"* {v} *");
            Console.WriteLine(new string('*', breedte));
        }
    }
}
