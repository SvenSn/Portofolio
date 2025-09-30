
namespace D11concataantalkeer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Schrijf een method ConcatAantalKeer die 2 parameters heeft : een tekst en een aantal.
            //Deze method produceert een string die de meegegeven tekst het gevraagde aantal keren bevat.


            string uitvoer = ConcatAantalKeer("*_",4);
            Console.WriteLine(uitvoer);

        }

        private static string ConcatAantalKeer(string v1, int v2)
        {
            string output = "";

            for (int i = 0; i < v2; i++)
            {
                output = output + v1;  
            }
            
            return output;  
        }
    }
}
