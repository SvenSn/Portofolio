namespace D02getalontleden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal in: ");
            int getal = Int32.Parse(Console.ReadLine());    



            int rest = getal;

            int honderd = rest / 100;
            rest = rest % 100;
            int tientallen = rest / 10;
            rest = rest % 10;
            int eenheden = rest;


            Console.WriteLine(honderd);
            Console.WriteLine(tientallen);
            Console.WriteLine(eenheden);

        }
    }
}
