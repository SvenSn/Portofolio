namespace D03_kleinermetif
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Schrijf een programma dat de gebruiker om twee gehele getallen vraagt en toont welk getal het kleinste is.
            // Gebruik hiervoor - bij wijze van oefening - eens een if/else structuur en niet Math.Min()!

            // gebruiker vragen om 2 gehele getallen te geven 
            Console.WriteLine("Geef het eerste gehele getal in");
            int getal1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Geef het tweede getal in");
            int getal2 = Int32.Parse(Console.ReadLine());

            // int kleinste getal aanmaken 
            int kleinsteGetal;

            // if/else om te checken wat het kleinere getal is 
            if (getal1 < getal2) 
            {
               kleinsteGetal = getal1;
            }
            else
            {
                kleinsteGetal = getal2;
            }


            Console.WriteLine($"Het kleinste getal is: {kleinsteGetal}");
        }
    }
}
