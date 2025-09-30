using Cui;
using Domein;
using Persistentie;

namespace StartUp
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			IBierRepository bierRepo = new BierRepository();
			DomeinController dc = new DomeinController(bierRepo);
			
			new BierApplicatie(dc).Run();
		}
	}
}