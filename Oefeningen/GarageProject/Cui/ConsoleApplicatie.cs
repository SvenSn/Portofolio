using Domein;
using System;

namespace Cui
{
	public class ConsoleApplicatie
	{
		private readonly DomeinController _domeinController;

		public ConsoleApplicatie(DomeinController dc)
		{
		   _domeinController = dc;
		}

		public virtual void Run()
		{
			Console.Write("autoDictionary\n{0}\n", _domeinController.AutoDictionaryToString());
			Console.Write("\nautoOnderhoudDictionary\n{0}\n", _domeinController.AutoOnderhoudDictionaryToString());
		}
	}
}