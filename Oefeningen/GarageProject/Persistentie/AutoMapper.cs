using Domein;
using System.Collections.Generic;

namespace Persistentie
{
	public class AutoMapper
	{
		public virtual List<Auto> GeefAutos()
		{
	        List<Auto> lijstAutos = new List<Auto>();
	        lijstAutos.Add(new Auto("123xyz", "Toyota", "Yaris"));
			lijstAutos.Add(new Auto("123xyz", "Toyota", "Yaris"));
			lijstAutos.Add(new Auto("567xyz", "Renault", "Fluence"));
			lijstAutos.Add(new Auto("456abc", "Opel", "Astra"));
	        lijstAutos.Add(new Auto("azerty", "BMW", "Berline"));
	        lijstAutos.Add(new Auto("qwerty", "Toyota", "Avensis"));
	        lijstAutos.Add(new Auto("789cde", "Mercedes", "C-klasse Berline"));
			lijstAutos.Add(new Auto("azerty", "BMW", "Berline"));
			lijstAutos.Add(new Auto("567xyz", "Renault", "Fluence"));
	        lijstAutos.Add(new Auto("ab12ab", "Opel", "Zafira"));
	        lijstAutos.Add(new Auto("xy12xy", "Peugeot", "308"));
	        return lijstAutos;
		}
	}

}