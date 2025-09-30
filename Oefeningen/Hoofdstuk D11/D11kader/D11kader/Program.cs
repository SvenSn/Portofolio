
namespace D11kader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method ToonInKader met 1 string parameter. Deze method toont de meegegeven string tussen sterretjes op de console.


            ToonKader("Hallo");




        }

        private static void ToonKader(string tekst)
        {

            int breedteSter = tekst.Length + 4;
            
            Console.WriteLine(new string('*', breedteSter));

            Console.WriteLine($"* {tekst} *");

            Console.WriteLine(new string('*', breedteSter));


        }
    }
}
