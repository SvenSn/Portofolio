
namespace D11kader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToonInKader("Hallo");
        }

        private static void ToonInKader(string tekst)
        {
            int lengteTekst = tekst.Length;
            string sterretjes = new string ('*',lengteTekst+4);
            Console.WriteLine(sterretjes);
            Console.WriteLine($"* {tekst} *");
            Console.WriteLine(sterretjes);
        }
    }
}
