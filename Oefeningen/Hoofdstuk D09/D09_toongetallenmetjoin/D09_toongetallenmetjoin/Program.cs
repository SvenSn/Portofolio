namespace D09_toongetallenmetjoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een programma dat de getallen in een int[] netjes gescheiden door komma’s op de console zet

            int[] getallen = { 4, 7, 9, 34, 2, 56, 34, 78 };

            Console.WriteLine(string.Join(", ", getallen));
        }
    }
}
