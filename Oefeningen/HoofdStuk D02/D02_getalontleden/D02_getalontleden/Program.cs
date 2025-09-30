namespace D02_getalontleden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Schrijf een programma dat de gebruiker om een geheel getal in [0,1000[ vraagt (dus van 0 t.e.m. 999) 
             * en vervolgens toont uit hoeveel honderdtallen, tientallen en eenheden dit bestaat.
              Tip : gebruik deling en modulo.*/

            Console.WriteLine("Geef een geheel getal in.");
            string geheelGetalTekst = Console.ReadLine();
            int geheelGetal = Int32.Parse(geheelGetalTekst);

            int honderd = geheelGetal / 100;
            geheelGetal = geheelGetal % 100;

            int tientallen = geheelGetal / 10;
            geheelGetal = geheelGetal % 10;

            int eenheden = geheelGetal;

            Console.WriteLine($"{honderd} x 100");
            Console.WriteLine($"{tientallen} x 10");
            Console.WriteLine($"{eenheden} x 1");


            
        }
    }
}
