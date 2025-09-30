namespace D02gemiddelde
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal in. ");
            string getalText = Console.ReadLine();  
            double getal = double.Parse(getalText);


            Console.Write("Geef een getal in. ");
            string getalText1 = Console.ReadLine();
            double getal1 = double.Parse(getalText1);

            Console.Write("Geef een getal in. ");
            string getalText2 = Console.ReadLine();
            double getal2 = double.Parse(getalText2);


            double gemiddelde = (getal + getal1 + getal2) / 3.0;


            Console.WriteLine($"Het gemiddelde is {gemiddelde}");

        }
    }
}
