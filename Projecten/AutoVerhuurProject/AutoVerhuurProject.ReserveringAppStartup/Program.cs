using AutoVerhuurProject.Domein;
using AutoVerhuurProject.Domein.Interfaces;
using AutoVerhuurProject.Persistentielaag.Database;
using AutoVerhuurProject.Presentatielaag.ReserveringApplaag;

namespace AutoVerhuurProject.ReserveringAppStartup
{
    public class Program
    {
        static void Main(string[] args)
        {

            IKlantRepositoryRead repo = new KlantRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            IReserveringRepositoryFull repo2 = new ReserveringRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            IAutoRepositoryRead repo3 = new AutoRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            IVestigingRepositoryRead repo4 = new VestigingRepositoryDB(@"Data Source=SVEN\SQLEXPRESS;Initial Catalog=AutoVerhuurDataseBase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            ReserveringManager rm = new ReserveringManager(repo, repo2, repo3, repo4);
            ReserveringApp app = new(rm);

            app.Run();
        }
    }
}
