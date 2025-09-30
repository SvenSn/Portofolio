
namespace D10_toongetallenmetmethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method ToonGetallen die een int[] als parameter heeft en de inhoud van deze array op de console zet

            int[] getallen = { 4, 7, 9, 34, 2, 56, 34, 78 };
            ToonGetallen(getallen);

        }

        private static void ToonGetallen(int[] getallen)
        {
           Console.WriteLine(string.Join(", ", getallen));
        }
    }
}
