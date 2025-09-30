namespace D02absolutewaarde
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Geef een getal in. ");
            string getalText = Console.ReadLine();
            int getal = int.Parse(getalText);

            int absoluteWaarde = 0;

            if (getal < 0 )
            {
                absoluteWaarde = getal * (-1);
            }
            else
            {
                absoluteWaarde = getal;
            }


            Console.WriteLine($"De absolute waarde is {absoluteWaarde}");
        }
    }
}
