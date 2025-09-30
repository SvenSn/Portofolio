namespace D03persecondewijzer
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int secPerMin = 60;
            const int secPerU = 60 * secPerMin;

            Console.WriteLine("Geef het aantal seconden in.");
            string secText = Console.ReadLine();
            int sec = int.Parse(secText);

            int rest = sec;

            int uren = rest / secPerU;
            rest = rest - uren * secPerU;

            int minuten = rest / secPerMin;
            rest = rest - minuten * secPerMin;

            int seconden = rest;


            Console.WriteLine($"{sec} is {uren}u, {minuten} minuten, {seconden} seconden.");
        }
    }
}
