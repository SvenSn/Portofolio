using AuthoVerhuurProject.Presentatielaag.GegevensApp;
using AutoVerhuurProject.Persistentielaag;

namespace AutoVerhuurProject.StartUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CSVVerwerkerDB bvw = new CSVVerwerkerDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            GegevensApp app = new GegevensApp(bvw);

            app.Run();
        }
    }
}
