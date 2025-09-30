namespace D03kleinermetif
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geef een getal in. ");
            string getal1Text = Console.ReadLine();
            int getal1 = int.Parse(getal1Text);

            Console.WriteLine("Geef een getal in. ");
            string getal2Text = Console.ReadLine();
            int getal2 = int.Parse(getal2Text);

            int kleinsteGetal;

            if (getal1 > getal2)
            {
                kleinsteGetal = getal2;
            }
            else
            {
                kleinsteGetal= getal1;
            }

            Console.WriteLine($"Het kleinste getal is {kleinsteGetal} ");
        }
    }
}
