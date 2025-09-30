namespace D03persecondewijzer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int secPerMin = 60;
            const int secPerUur = secPerMin * 60;


            Console.WriteLine("Geef een aantal seconden in.");
            int seconden = int.Parse(Console.ReadLine());
            
            

            int rest = seconden;
            int aantalUren = rest / secPerUur; 
            rest = rest - aantalUren * secPerUur;

            int aantalMinuten = rest / secPerMin;
            rest = rest - aantalMinuten * secPerMin;

            int aantalSeconden = rest;

            Console.WriteLine($"{seconden} is {aantalUren}U, {aantalMinuten} minuten, {aantalSeconden} seconden.");
            

        }
    }
}
