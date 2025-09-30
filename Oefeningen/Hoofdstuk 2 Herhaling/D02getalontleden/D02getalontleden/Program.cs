namespace D02getalontleden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal in. ");
            string getalText = Console.ReadLine();
            int getal = int.Parse(getalText);


            int deling = getal;


            int honderd = deling / 100;
            deling =deling - (honderd *  100);
            int tientallen = deling / 10;
            deling = deling - (tientallen * 10);

            int eenheden = deling / 1;

            Console.WriteLine($"Het getal {getal} bestaat uit ");
            Console.WriteLine($"{honderd} x 100 ");
            Console.WriteLine($"{tientallen} x 10 ");
            Console.WriteLine($"{eenheden} x 1 ");

        }
    }
}
