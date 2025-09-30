namespace D04dagnummer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een dagnummer in. ");
            int dagnummer = int.Parse(Console.ReadLine());

            string maand = "";

            if ( dagnummer <=31)
            {
                maand = "Januari";
            } 
            else if (dagnummer <= 59)
            {
                maand = "Februari";
            }
            else if (dagnummer <= 90)
            {
                maand = "Maart";
            }
            else if (dagnummer <= 120)
            {
                maand = "april";
            }
            else if (dagnummer <= 151)
            {
                maand = "mei";
            }
            else if (dagnummer <= 181)
            {
                maand = "Juni";
            }
            else if (dagnummer <= 212)
            {
                maand = "Juli";
            }
            else if (dagnummer <= 243)
            {
                maand = "Augustus";
            }
            else if (dagnummer <= 273)
            {
                maand = "September";
            }
            else if (dagnummer <= 304)
            {
                maand = "Oktober";
            }
            else if (dagnummer <= 334)
            {
                maand = "November";
            }
            else if (dagnummer <= 365)
            {
                maand = "December";
            }


            Console.WriteLine($"De maand is {maand}");

            
        }
    }
}
