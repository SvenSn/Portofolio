namespace Domein
{

	public class DomeinController
	{
		private Garage _garage;
		public DomeinController(IAutoRepository autoRepo, IOnderhoudRepository onderhoudRepo)
		{
			_garage = new Garage(autoRepo, onderhoudRepo);
		}
		public string AutoDictionaryToString()
		{
			return _garage.ConvertAutoDictionaryToString();
		}
		public string AutoOnderhoudDictionaryToString()
		{
			return _garage.ConvertAutoOnderhoudDictionaryToString();
		}
	}

}